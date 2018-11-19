using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using Excel;
using ExcelDataReader;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace Loaned_PC_Tracker_Server {
    public partial class PCTrackerServerForm : Form {
		private int Interval = 30;
        private TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
        private Thread AcceptClients;
        private List<Site> siteList = new List<Site>();
		private string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                  Path.DirectorySeparatorChar + "Documents" +
		                          Path.DirectorySeparatorChar + "Inventory Tracker" + Path.DirectorySeparatorChar;
        private string SiteFileName = "Sites.xlsx";
        private LoadingProgress ProgressBarForm;
        private int ProgressMax;
        private bool Changed;
        private bool WindowDrawn;
        private List<Client> ClientList = new List<Client>();

        private delegate void StringParameterDelegate(string value);

        public PCTrackerServerForm() {
            InitializeComponent();
        }

        /// <summary>
        ///     update the tbLog.Text with any server messages, from any and all threads
        /// </summary>
        /// <param name="message"></param>
        public void UpdateStatus(string message) {
            if (InvokeRequired) {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] { message });
                return;
            }
            // Must be on the UI thread if we've got this far
            if (!tbLog.IsDisposed) {
                tbLog.AppendText(message);
                tbLog.AppendText(Environment.NewLine);
            }
        }

        public void RemoveClient(Client client) {
            ClientList.Remove(client);
        }

        /// <summary>
        ///     start loading up after the windows draws on the desktop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PCTrackerServerForm_Activated(object sender, EventArgs e) {
            if (!WindowDrawn) {
                WindowDrawn = true;
                UpdateStatus(">>>> Starting Server <<<<");
                UpdateStatus("> Loading Sites...");
                bgwLoadSites.RunWorkerAsync();
                ProgressBarForm = new LoadingProgress("Loading Sites List");
                ProgressBarForm.ShowDialog();
            }
        }

        /// <summary>
        ///     open and read the sites from the requested site file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_DoWork(object sender, DoWorkEventArgs e) {
			string fileName = FilePath + SiteFileName;

			//Transform the data in to a table to pass to the other functions.
			DataTable dTable = GetRODataTable(fileName, false);

			int localSitesNum = intCheckNull(dTable.Rows[0][1]);

			FillSiteList(localSitesNum, dTable);
        }

		/// <summary>
		/// 	
		/// </summary>
		/// <returns>The data table.</returns>
		/// <param name="file">File.</param>
		/// <param name="colNames">If set to <c>true</c> col names.</param>
		private DataTable GetRODataTable(string file, bool colNames) {
			FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
			IExcelDataReader excelReader;

			//1. Reading Excel file
			if (Path.GetExtension(file).ToUpper() == ".XLS") {
				//1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
				excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
			} else {
				//1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
				excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			}

            //2. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = colNames;

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result;

            if (colNames) {
                result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
            } else {
                result = excelReader.AsDataSet();
            }


            //4. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

			return result.Tables[0];
		}

        /// <summary>
        ///     load the sites into the siteList variable
        /// </summary>
        /// <param name="sitesNum"></param>
        /// <param name="dTable"></param>
        private void FillSiteList(int sitesNum, DataTable dTable) {
            ProgressMax = sitesNum;
            string siteName;
            for (int i = 1; i <= sitesNum; i++) {
				siteName = (stringCheckNull(dTable.Rows[i][0])).Split(' ')[0];
                siteList.Add(new Site(siteName));
                UpdateStatus("> " + siteName);
                bgwLoadSites.ReportProgress(i);
            }
        }

        /// <summary>
        ///     update the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (ProgressBarForm.getProgressMaximum() != ProgressMax) {
                ProgressBarForm.setProgressMaximum(ProgressMax);
            }
            ProgressBarForm.updateProgress(e.ProgressPercentage);
        }

        /// <summary>
        ///     after filling the siteList variable, this will go on to load up the PCs from 
        ///     each site, both:
        ///     Hotswaps (temporary shell replacement) and
        ///     Loaners (temporary use PC while permanent PC is being worked on)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ProgressBarForm.Close();
            //load up the PC's for each site
            foreach (Site site in siteList) {
                UpdateStatus("> Loading PCs for " + site.Name + "...");
                //sends the current site object to the backgroundworker as an argument
                bgwLoadPCs.RunWorkerAsync(site);
                ProgressBarForm = new LoadingProgress("Loading PC Lists");
                ProgressBarForm.ShowDialog();
            }
            //this begins the Asynchronous thread for the auto-save feature.
            bgwAutoSave.RunWorkerAsync();
            //this goes on to open the server socket for on-coming user connections.
            openConnection();
        }
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadPCs_DoWork(object sender, DoWorkEventArgs e) {
			//interprets the argument sent to the backgroundworker as a Site object
			Site site = (Site)e.Argument;

			string fileName = FilePath + site.Name + Path.DirectorySeparatorChar + "Loaners.xlsx";
			addLaptopstoSite(false, site, GetRODataTable(fileName, true));

			fileName = FilePath + site.Name + Path.DirectorySeparatorChar + "Hotswaps.xlsx";
			addLaptopstoSite(true, site, GetRODataTable(fileName, true));
        }

        /// <summary>
        ///     opens the worksheet and gets the laptop information to be added to either
        ///     the site's hotswap or loaner list
        /// </summary>
        /// <param name="hotswaps"></param>
        /// <param name="site"></param>
        /// <param name="workbook"></param>
        private void addLaptopstoSite(bool hotswaps, Site site, DataTable dTable) {
			int lastRow = dTable.Rows.Count;
            ProgressMax = lastRow;

            Laptop newLaptop;
            Laptop prevLaptop = new Laptop();

            for (int index = 2; index <= lastRow; index++) {
				newLaptop = getNewLaptop(index, ref dTable);
                //this verifies that the newly created laptop is not a copy of the previous one
                if (newLaptop != prevLaptop) {
                    if (hotswaps) {
                        site.Hotswaps.Add(newLaptop);
                    } else {
                        site.Loaners.Add(newLaptop);
                    }
                    UpdateStatus(newLaptop.Brand + " " + newLaptop.Model + " " + newLaptop.Serial);
                    bgwLoadPCs.ReportProgress(index);
                    prevLaptop = newLaptop;
                }
            }
        }

        /// <summary>
        ///     reads each column of the indexed row to create a laptop object
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sheet"></param>
        /// <returns>
        ///     a new Laptop object with information read from the sheet
        /// </returns>
        //private Laptop getNewLaptop(int index, ref Excel.Worksheet sheet) {
		private Laptop getNewLaptop(int index, ref DataTable dTable) {
			int lastCol = dTable.Columns.Count;
			// this array holds all of the information from each line of the excel sheet
			Array laptopValues = (Array)dTable.Rows[index].ItemArray;
			// I have to run the check null on each of these parsed cells, 
		 	// due to being brought in from an excel sheet with possible blank cells
			Laptop newLaptop = new Laptop() {
				Number = intCheckNull(laptopValues.GetValue(0)),
	            Serial = stringCheckNull(laptopValues.GetValue(1)),
	            Brand = stringCheckNull(laptopValues.GetValue(2)),
	            Model = stringCheckNull(laptopValues.GetValue(3)),
	            Warranty = stringCheckNull(laptopValues.GetValue(4)),
	            Username = stringCheckNull(laptopValues.GetValue(5)),
	            UserPCSerial = stringCheckNull(laptopValues.GetValue(6)),
	            TicketNumber = stringCheckNull(laptopValues.GetValue(7)),
	            CheckedOut = boolCheckNull(laptopValues.GetValue(8))
            };
            return newLaptop;
        }

        /// <summary>
        ///     updates the progress bar of the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadPCs_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (ProgressBarForm.getProgressMaximum() != ProgressMax) {
                ProgressBarForm.setProgressMaximum(ProgressMax);
            }
            ProgressBarForm.updateProgress(e.ProgressPercentage);
        }

        /// <summary>
        ///     closes the progress bar dialog, once completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadPCs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            ProgressBarForm.Close();
        }

        /// <summary>
        ///     check for a blank cell value and return a string, if that is expected
        /// </summary>
        /// <param name="value"></param>
        /// <returns> a string of the cell contents</returns>
        private string stringCheckNull(object value) {
            if (value == null) {
                return "";
            }
            return value.ToString();
        }

        /// <summary>
        ///     check for a blank cell value and return a boolean, if that is expected
        /// </summary>
        /// <param name="value"></param>
        /// <returns> a if the cell contents are null or true/false</returns>
        private bool boolCheckNull(object value) {
            if (value == null) {
                return false;
            }
            if ((bool)value) {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     check for a blank cell value and return an integer, if that is expected
        /// </summary>
        /// <param name="value"></param>
        /// <returns> 0 if the cell is blank or the object doesn't parse, otherwise returns an int value</returns>
        private int intCheckNull(object value) {
            if (value == null) {
                return 0;
            }
            //the following will parse the value out to make sure it is a number, before assigning and returning
            int parsedNum;
            if (int.TryParse(value.ToString(), out parsedNum)) {
                return parsedNum;
            } else {
                return 0;
            }
        }

        /// <summary>
        ///     returns a full column name using the column number as a basis
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        private string ColumnNumToString(int columnNumber) {
            int dividend = columnNumber;
            string strColumnName = "";
            int modulo;
            while (dividend > 0) {
                modulo = (dividend - 1) % 26;
                strColumnName = Convert.ToChar(65 + modulo).ToString() + strColumnName;
                dividend = ((dividend - modulo) / 26);
            }
            return strColumnName;
        }

        /// <summary>
        ///     Starts the server socket and creates a thread to continually accept new connections
        /// </summary>
        private void openConnection() {
            serverSocket.Start();
            UpdateStatus(">> Server Started");

            AcceptClients = new Thread(ConnectClient);
            AcceptClients.Start(serverSocket);
        }

        /// <summary>
        ///     awaits the connection of a client via the specified socket, and 
        ///     creates a new Client object thread
        /// </summary>
        /// <param name="parameter"></param>
        private void ConnectClient(object parameter) {
            var serverSock = parameter as TcpListener;
            var clientSock = new TcpClient();
            //create a permanent loop to accept clients, while the server is active
            while (true) {
                try {
                    clientSock = serverSock.AcceptTcpClient();
                    //create the client object, once a connection is accepted
                    Client newClient = new Client(clientSock, this);
                    //add that new Client to the List of Client objects
                    ClientList.Add(newClient);
                    UpdateStatus(">> Client " + newClient.UserName + " connected!");
                    //send the sites to the client, after connection is established
                    SendSitesToClient(newClient);
                } catch (Exception ex) {
                    UpdateStatus("XXX " + ex.Message);
                    break;
                }
            }
        }

        /// <summary>
        ///     gathers the site list, serializes the data and sends it to the client
        /// </summary>
        /// <param name="client"></param>
        private void SendSitesToClient(Client client) {
            UpdateStatus(">>> Sending sites to: " + client.UserName);
            
            //create a jagged array to store each serialzed site name
            byte[][] serializedData = new byte[siteList.Count][];
            foreach(Site site in siteList) {
                int index = siteList.IndexOf(site);
                serializedData[index] = new byte[site.Name.Length];
                serializedData[index] = SerializeString(site.Name);
            }

            List<byte> fullDataStream = new List<byte>();
            //add the serialized data for each site to a List to be sent to the client
            foreach (byte[] array in serializedData) {
                fullDataStream.AddRange(array);
            }
            client.StreamDataToClient(fullDataStream.ToArray(), this);
        }

        /// <summary>
        ///     serialize a string for data transfer
        /// </summary>
        /// <param name="s"></param>
        /// <returns>
        ///     a byte array with the data of the string
        /// </returns>
        private byte[] SerializeString(string s) {
            string stringToSerialize = s.Insert(s.Length, ";");
            byte[] serializedString = Encoding.UTF8.GetBytes(stringToSerialize);
            return serializedString;
        }
        
        /// <summary>
        ///     gathers the data of all the requested PCs of the requested type and
        ///     sends them to the client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="siteName"></param>
        /// <param name="type"></param>
        public void SendPCsForSite(Client client, string siteName, string type) {
            var dataStream = new List<byte>();
            //add the identifier to the data stream
            dataStream.AddRange(BitConverter.GetBytes((int)DataIdentifier.Laptop));
            dataStream.AddRange(BitConverter.GetBytes(';'));
            //get the requested site from the List
            Site site = siteList.Find(s => s.Name == siteName);
            if (type == "Hotswaps") {
                foreach (Laptop pc in site.Hotswaps) {
                    dataStream.AddRange(pc.SerializeLaptop());
                }
            } else {
                foreach (Laptop pc in site.Loaners) {
                    dataStream.AddRange(pc.SerializeLaptop());
                }
            }
            UpdateStatus(">>> Sending " + type + " from " + siteName + " to " + client.UserName);
            client.StreamDataToClient(dataStream.ToArray(), this);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveChanges();
        }

        /// <summary>
        ///     this will iterate through each site and send that site's Lists for 
        ///     saving in the spreadsheets
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="hotswaps"></param>
        private void SaveChanges() {

			/*Excel.Application excelApp = new Excel.Application() {
                Visible = false,
                DisplayAlerts = false
            };*/
			//FileStream stream;
			IExcelDataReader excelReader = null;
			foreach (Site site in siteList) {
				UpdateStatus("<< Saving " + site.Name + "'s PC lists");
				//Excel.Workbook workbook = excelApp.Workbooks.Open(FilePath + site.Name + "\\Loaners.xlsx");

				string file = FilePath + site.Name + "\\Loaners.xlsx";

				//3. DataSet - The result of each spreadsheet will be created in the result.Tables
				AccessFileDataSet(file, ref excelReader);//excelReader.AsDataSet();

				//FillSheet(site.Loaners, workbook);
				FillSheet(site.Loaners, ref excelReader);

				excelReader.AsDataSet().AcceptChanges();

				//workbook = excelApp.Workbooks.Open(FilePath + site.Name + "\\Hotswaps.xlsx");

				//FillSheet(site.Hotswaps, workbook);
            }
			excelReader.Close();
            //excelApp.Quit();
            Changed = false;
        }

		private void AccessFileDataSet(string file, ref IExcelDataReader excelReader) {
			FileStream stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite);

			//1. Reading Excel file
			if (Path.GetExtension(file).ToUpper() == ".XLS") {
				//1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
				excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
			} else {
				//1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
				excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			}

            //2. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = true;
            excelReader.AsDataSet(new ExcelDataSetConfiguration() {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() {
                    UseHeaderRow = true
                }
            });
        }

        /// <summary>
        ///     read each part of each laptop and place it in the spreadsheets
        /// </summary>
        /// <param name="PCs"></param>
        /// <param name="workbook"></param>
		private void FillSheet(List<Laptop> PCs, ref IExcelDataReader excelReader) {
			//var sheet = (Excel.Worksheet)workbook.Worksheets.Item[1];
			DataTable table = excelReader.AsDataSet().Tables[0];
            int lastrow = 1;
            foreach (Laptop PC in PCs) {
				//table.Rows[lastrow].Delete();
				table.Rows[lastrow][1] = PC.Number.ToString();
                table.Rows[lastrow][2] = PC.Serial;
                table.Rows[lastrow][3] = PC.Brand;
                table.Rows[lastrow][4] = PC.Model;
                table.Rows[lastrow][5] = PC.Warranty;
                table.Rows[lastrow][6] = PC.Username;
                table.Rows[lastrow][7] = PC.UserPCSerial;
                table.Rows[lastrow][8] = PC.TicketNumber;
                table.Rows[lastrow][9] = PC.CheckedOut;
                lastrow++;
            }
            //workbook.Save();
            //workbook.Close();
        }

        /// <summary>
        ///     runs the save function at set intervals
        ///     You'll notice a lot of things hinge on whether or not there is a cancellation
        ///     pending, this is so when the user turns the auto-save feature off, it will 
        ///     just move it's way out of the method without running the save feature again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAutoSave_DoWork(object sender, DoWorkEventArgs e) {
            UpdateStatus("** AutoSave Enabled **");
            while (!bgwAutoSave.CancellationPending) {
                DateTime start = DateTime.Now;
                //TODO: add the ability for the user to set the interval
                while (DateTime.Now.Subtract(start).Minutes < Interval) {
                    if (bgwAutoSave.CancellationPending) {
                        break;
                    }
                }
                if (!bgwAutoSave.CancellationPending) {
                    SaveChanges();
                    UpdateStatus("<< Saving completed!");
                    UpdateStatus("<< Saving Log!");
                    string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Day.ToString() + "-"
                        + DateTime.Now.Month.ToString() + " " + DateTime.Now.ToString("HH.mm.ss tt");
                    string logFile = FilePath + "logs" + Path.DirectorySeparatorChar + "log - " + date + ".txt";
                    if (!File.Exists(logFile)) {
                        File.Create(logFile).Dispose();
                    }
                    File.AppendAllText(logFile, tbLog.Text);
                }
            }
        }
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAutoSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            UpdateStatus("** Warning: AutoSave Disabled **");
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="changedPC"></param>
        /// <param name="client"></param>
        public void updatePC(PCChange changedPC, Client client) {
            Site site = siteList.Find(s => s.Name == client.Site);
            Laptop PCtoEdit;

            if (client.Hotswaps) {
                PCtoEdit = site.Hotswaps.Find(pc => pc.Serial == changedPC.Serial);
            } else {
                PCtoEdit = site.Loaners.Find(pc => pc.Serial == changedPC.Serial);
            }

            string modification = string.Empty;
            if (changedPC.CheckedOut) {
                modification = " is checking out ";
            } else {
                modification = " is checking in ";
            }
            UpdateStatus(">>> User " + client.UserName + modification + PCtoEdit.Serial +
                         " from site " + client.Site);
            Changed = true;
            PCtoEdit.MergeChanges(changedPC);

            UpdateStatus(">> Sending updates to other clients connected to " + client.Site);
            BroadcastUpdateToSite(PCtoEdit, client);
        }

        /// <summary>
        ///     sends out the received message to each client that is connected.
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="flag"></param>
        public void BroadcastUpdateToSite(string broadcastMsg, Client client) {
            var serializedData = new List<byte>();
            serializedData.AddRange(BitConverter.GetBytes((int)DataIdentifier.Broadcast));
            serializedData.AddRange(SerializeString(broadcastMsg));
            foreach (Client c in ClientList.FindAll(c => (c.Site == client.Site && c.Hotswaps == client.Hotswaps))) {
                if(c != client) {
                    UpdateStatus(">>> Sending update broadcast to " + c.UserName);
                    c.StreamDataToClient(serializedData.ToArray(), this);
                }
            }
        }

        /// <summary>
        ///     sends out the broadcast to each client that is connected.
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="flag"></param>
        public void BroadcastUpdateToSite(Laptop updatedPC, Client client) {
            var serializedData = new List<byte>();
            serializedData.AddRange(BitConverter.GetBytes((int)DataIdentifier.Update));
            serializedData.AddRange(updatedPC.SerializeLaptop());
            foreach (Client c in ClientList.FindAll(c => (c.Site == client.Site && c.Hotswaps == client.Hotswaps))) {
                if (c != client) {
                    UpdateStatus(">>> Sending update broadcast to " + c.UserName);
                    c.StreamDataToClient(serializedData.ToArray(), this);
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PCTrackerServerForm_Closing(object sender, FormClosingEventArgs e) {
            serverSocket.Stop();
            AcceptClients.Abort();
            do {
                bgwAutoSave.CancelAsync();
            } while (!bgwAutoSave.IsBusy);
            if (Changed) {
                SaveChanges();
            }
            string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString();
            string logFile = FilePath + "logs" + Path.DirectorySeparatorChar + "log - " + date + ".txt";
            if (!File.Exists(logFile)) {
				File.Create(logFile).Dispose();
            }
            File.AppendAllText(logFile, tbLog.Text);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testBroadcastToolStripMenuItem_Click(object sender, EventArgs e) {
            string test = "abcdefghijklmnopqrstuvwxyz1234567890-=[]\\',./`ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_+{}|:\"<>?~";
            var serializedData = new List<byte>();
            serializedData.AddRange(BitConverter.GetBytes((int)DataIdentifier.Broadcast));
            serializedData.AddRange(SerializeString(test));
            foreach (Client c in ClientList) {
                UpdateStatus(">> Sending Test Broadcast to " + c.UserName);
                c.StreamDataToClient(serializedData.ToArray(), this);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoSaveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (autoSaveToolStripMenuItem.Checked) {
                if (!bgwAutoSave.IsBusy) {
                    bgwAutoSave.RunWorkerAsync();
                }
            } else {
                bgwAutoSave.CancelAsync();
            }
        }
    }
}
