using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using Inventory_Tracker_Server;

namespace Inventory_Tracker_Client {
    public partial class ViewEditPcs : Form {
        private const string KeyLocation = "SOFTWARE\\Inventory Tracker";
        private Microsoft.Win32.RegistryKey ProgramKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KeyLocation);
        private string Server = "MXL3090GHT-X7";
        private BindingList<Laptop> CurrentlyAvailable = new BindingList<Laptop>();
        private BindingList<Laptop> CheckedOut = new BindingList<Laptop>();
        private BindingList<string> siteList = new BindingList<string>();
        
        private LoadingProgress ProgressBarForm;
        //private int ProgressMax;
        private bool WindowLoaded;
        private TcpClient ClientSocket = new TcpClient() {
            NoDelay = true,
        };
        private delegate void StringParameterDelegate(string value);
        private delegate void LaptopParameterDelegate(Laptop laptop);

        public ViewEditPcs() {
            InitializeComponent();

            cbSiteChooser.DataSource = siteList;
            dgvAvailable.DataSource = CurrentlyAvailable;
            dgvCheckedOut.DataSource = CheckedOut;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTracker_Activated(object sender, EventArgs e) {
            if (!WindowLoaded) {
                WindowLoaded = true;
                int numRetries = 1;
                using (var connectTo = new ConnectionForm(Server)) {
                    var result = connectTo.ShowDialog();
                    if (result == DialogResult.OK) {
                        Server = connectTo.ReturnAddress;
                        numRetries = connectTo.ReturnRetries;
                    } else {
                        UpdateStatus("Connection Failed! Please restart the application!");
                        return;
                    }
                }
                ConnectToServer(numRetries);
                bgwLoadSites.RunWorkerAsync();
                ProgressBarForm = new LoadingProgress("Receiving Sites List");
                ProgressBarForm.ShowDialog();
            }
        }

        private void ConnectToServer(int retries) {
            //this loop allows for multiple attempts to connect to the server before timing out
            for (int i = 0; i < retries; i++) {
                UpdateStatus(">>Attempting to connect...");
                try {
                    ClientSocket.Connect(Server, 8888);
                } catch (Exception ex) {
                    UpdateStatus(ex.Message);
                }

                //once connected, the client sends a packet to the server to agknowledge logging in.
                if (ClientSocket.Connected) {
                    NetworkStream loginStream = ClientSocket.GetStream();
                    NamePacket handshake = new NamePacket(Environment.UserName);
                    loginStream.Write(handshake.CreateDataStream(), 0, handshake.PacketLength);
                    loginStream.Flush();
                    UpdateStatus("Server Connected ... " + Server);
                    //bwBroadcastStream.RunWorkerAsync();
                    break;
                }
                UpdateStatus(">> Waiting 3 Seconds before trying again.");
                DateTime start = DateTime.Now;
                while (DateTime.Now.Subtract(start).Seconds < 3) { }
            }
            if (!ClientSocket.Connected) {
                UpdateStatus("Connection Failed!!");
            }
        }

        public void UpdateStatus(string message) {
            if (InvokeRequired) {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] { message });
                return;
            }
            // Must be on the UI thread if we've got this far
            tbConnectionStatus.AppendText(message);
            tbConnectionStatus.AppendText(Environment.NewLine);
            
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTracker_Resize(object sender, EventArgs e) {
            Form sent = sender as Form;
            if (sent.WindowState == FormWindowState.Maximized) {
                dgvAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCheckedOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            } else {
                dgvAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvCheckedOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_DoWork(object sender, DoWorkEventArgs e) {
            
            byte[] inStream = new byte[10025];
            try {
                ClientSocket.GetStream().Read(inStream, 0, ClientSocket.ReceiveBufferSize);
                List<string> sites = DeserializeStringStream(inStream);
                foreach(string s in sites) {
                    siteList.Add(s);
                }
            } catch (Exception ex) {
                UpdateStatus(ex.Message);
            }
        }

        private List<string> DeserializeStringStream(byte[] stream) {
            string stringStream = Encoding.UTF8.GetString(stream);
            string[] splitStream = stringStream.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            return splitStream.ToList();
        }
        
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_ProgressChanged(object sender, ProgressChangedEventArgs e) {
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadSites_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            siteList.ResetBindings();

            int index = cbSiteChooser.FindString(GetDefaultSite(ProgramKey));
            cbSiteChooser.SelectedIndex = index;
            btnSetDefaultSite.Enabled = false;

            ProgressBarForm.Close();
            bgwAwaitBroadcasts.RunWorkerAsync();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSiteChooser_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbSiteChooser.SelectedIndex != cbSiteChooser.FindString(GetDefaultSite(ProgramKey))) {
                rbHidden.Checked = true;
                btnSetDefaultSite.Enabled = true;
                CurrentlyAvailable.Clear();
                CheckedOut.Clear();
            } else {
                btnSetDefaultSite.Enabled = false;
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetDefaultSite_Click(object sender, EventArgs e) {
            SetDefaultSite(ProgramKey);
            btnSetDefaultSite.Enabled = false;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetDefaultSite(Microsoft.Win32.RegistryKey key) {
            if (key == null) {
                SetDefaultSite(key);
                return (string)cbSiteChooser.SelectedItem;
            }
            return (string)key.GetValue("Default Site");
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="key"></param>
        private void SetDefaultSite(Microsoft.Win32.RegistryKey key) {
            string siteName = (string)cbSiteChooser.SelectedItem;

            if (key == null) {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KeyLocation);
                key.SetValue("Default Site", siteName);
            } else {
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(KeyLocation);
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KeyLocation);
                key.SetValue("Default Site", siteName);
            }
            key.Close();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbLoaner_CheckedChanged(object sender, EventArgs e) {
            RadioButton sent = sender as RadioButton;
            if (sent.Checked) {
                ClearPCLists();
                EnableDisableButtons(true);
                dgvAvailable.Columns[0].Visible = true;
                dgvCheckedOut.Columns[0].Visible = true;
                AccessLoanedPCData((string)cbSiteChooser.SelectedItem, false);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHotSwap_CheckedChanged(object sender, EventArgs e) {
            RadioButton sent = sender as RadioButton;
            if (sent.Checked) {
                ClearPCLists();
                EnableDisableButtons(true);
                dgvAvailable.Columns[0].Visible = false;
                dgvCheckedOut.Columns[0].Visible = false;
                AccessLoanedPCData((string)cbSiteChooser.SelectedItem, true);
            }
        }

        private void ClearPCLists() {
            CurrentlyAvailable.Clear();
            CheckedOut.Clear();
        }

        private void EnableDisableButtons(bool disposition) {
            btnAddNew.Enabled = disposition;
            btnCheckIn.Enabled = disposition;
            btnCheckOut.Enabled = disposition;
            btnEditPC.Enabled = disposition;
            btnRemoveOld.Enabled = disposition;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="siteName"></param>
        /// <param name="hotswaps"></param>
        private void AccessLoanedPCData(string siteName, bool hotswaps) {
            string type = string.Empty;
            if (hotswaps) {
                type = "Hotswaps";
            } else {
                type = "Loaners";
            }

            RequestPCPacket requestPCs = new RequestPCPacket(siteName, type);
            try {
                UpdateStatus("Requesting " + type + " for " + requestPCs.SiteName);
                ClientSocket.GetStream().Write(requestPCs.CreateDataStream(), 0, requestPCs.PacketLength);
                ClientSocket.GetStream().Flush();
            } catch(Exception ex) {
                UpdateStatus(ex.Message);
            }
            ProgressBarForm = new LoadingProgress("Loading " + type + " List");
            ProgressBarForm.ShowDialog();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAvailable_CellClick(object sender, DataGridViewCellEventArgs e) {
            Viewer viewItem = new Viewer((Laptop)dgvAvailable.SelectedRows[0].DataBoundItem);
            viewItem.ShowDialog();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCheckedOut_CellClick(object sender, DataGridViewCellEventArgs e) {
            Viewer viewItem = new Viewer((Laptop)dgvCheckedOut.SelectedRows[0].DataBoundItem);
            viewItem.ShowDialog();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckOut_Click(object sender, EventArgs e) {
            if (CurrentlyAvailable.Count > 0) {
                Laptop checkOutPC = (Laptop)dgvAvailable.SelectedRows[0].DataBoundItem;
                if (checkOutPC != null) {
                    using (var form = new CheckOutOrIn(checkOutPC, rbHotSwaps.Checked)) {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK) {
                            checkOutPC = form.ReturnPC;
                            CurrentlyAvailable.Remove(checkOutPC);
                            CheckedOut.Add(checkOutPC);
                            var checkedOutPacket = new PCChange(checkOutPC);
                            try {
                                NetworkStream stream = ClientSocket.GetStream();
                                stream.Write(checkedOutPacket.CreateDataStream(), 0, checkedOutPacket.PacketLength);
                                stream.Flush();
                            } catch (Exception ex) {
                                UpdateStatus(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckIn_Click(object sender, EventArgs e) {
            if (CheckedOut.Count > 0) {
                Laptop checkInPC = (Laptop)dgvCheckedOut.SelectedRows[0].DataBoundItem;
                if (checkInPC != null) {
                    using (var form = new CheckOutOrIn(checkInPC, rbHotSwaps.Checked, true)) {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK) {
                            checkInPC = form.ReturnPC;
                            CheckedOut.Remove(checkInPC);
                            CurrentlyAvailable.Add(checkInPC);
                            var checkedInPacket = new PCChange(checkInPC);
                            try {
                                NetworkStream stream = ClientSocket.GetStream();
                                stream.Write(checkedInPacket.CreateDataStream(), 0, checkedInPacket.PacketLength);
                                stream.Flush();
                            } catch (Exception ex) {
                                UpdateStatus(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditPC_Click(object sender, EventArgs e) {
            if (CurrentlyAvailable.Count > 0) {
                Laptop editedPC = (Laptop)dgvAvailable.SelectedRows[0].DataBoundItem;
                using (var form = new AddEditRemove(editedPC, false, rbHotSwaps.Checked)) {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) {
                        CurrentlyAvailable.Remove(editedPC);
                        editedPC = form.ReturnPC;
                        CurrentlyAvailable.Add(editedPC);
                    }
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNew_Click(object sender, EventArgs e) {
            using (var form = new AddEditRemove(rbHotSwaps.Checked)) {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) {
                    CurrentlyAvailable.Add(form.ReturnPC);
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveOld_Click(object sender, EventArgs e) {
            if (CurrentlyAvailable.Count > 0) {
                Laptop PCtoRemove = (Laptop)dgvAvailable.SelectedRows[0].DataBoundItem;
                using (var form = new AddEditRemove(PCtoRemove, true, rbHotSwaps.Checked)) {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) {
                        CurrentlyAvailable.Remove(PCtoRemove);
                    }
                }
            }
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPCTracker_Closing(object sender, FormClosingEventArgs e) {
			
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAwaitBroadcasts_DoWork(object sender, DoWorkEventArgs e) {
            NetworkStream broadcastStream;
            byte[] inStream = new byte[10025];
            while (true) {
                try {
                    broadcastStream = ClientSocket.GetStream();
                    broadcastStream.Read(inStream, 0, ClientSocket.ReceiveBufferSize);
                    var streamIdentifier = (DataIdentifier)BitConverter.ToInt32(inStream, 0);
                    if (streamIdentifier == DataIdentifier.Broadcast) {
                        List<string> broadcast = DeserializeStringStream(inStream);
                        foreach (string s in broadcast) {
                            UpdateStatus(s);
                        }
                    } else if (streamIdentifier == DataIdentifier.Laptop) {
                        SplitAndAddPCStream(inStream);
                        bgwAwaitBroadcasts.ReportProgress(0);
                    } else if (streamIdentifier == DataIdentifier.Update) {
                        Laptop updatedPC = new Laptop(inStream.Skip(4).ToArray());
                        UpdateLaptop(updatedPC);
                        bgwAwaitBroadcasts.ReportProgress(0);
                    } else if (streamIdentifier == DataIdentifier.Null) {
                    }
                } catch (Exception ex) {
                    UpdateStatus(ex.Message);
                    //TODO: add a prompt for the user to reconnect to the server.
                    break;
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="dataStream"></param>
        private void SplitAndAddPCStream(byte[] dataStream) {
            var seperator = new char[] { ';' };
            var stringStream = Encoding.UTF8.GetString(dataStream);
            var splitStream = stringStream.Split(seperator);
            for(int i = 1; i < splitStream.Length - 1; i++) {
                AddLaptop(new Laptop().Deserialize(splitStream[i]));
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="newLaptop"></param>
        private void AddLaptop(Laptop newLaptop) {
            if (InvokeRequired) {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new LaptopParameterDelegate(AddLaptop), new object[] { newLaptop });
                return;
            }
            // Must be on the UI thread if we've got this far
            if (newLaptop.CheckedOut) {
                CheckedOut.Add(newLaptop);
            } else {
                CurrentlyAvailable.Add(newLaptop);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="newLaptop"></param>
        private void UpdateLaptop(Laptop updatedPC) {
            if (InvokeRequired) {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new LaptopParameterDelegate(UpdateLaptop), new object[] { updatedPC });
                return;
            }
            // Must be on the UI thread if we've got this far
            if (!CurrentlyAvailable.Union(CheckedOut).Contains(updatedPC)) {
                if (updatedPC.CheckedOut) {
                    CheckedOut.Add(updatedPC);
                } else {
                    CurrentlyAvailable.Add(updatedPC);
                }
            } else if (CurrentlyAvailable.Contains(updatedPC)) {
                CurrentlyAvailable.Remove(updatedPC);
                CheckedOut.Add(updatedPC);
            } else {
                CheckedOut.Remove(updatedPC);
                CurrentlyAvailable.Add(updatedPC);
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAwaitBroadcasts_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            CurrentlyAvailable.ResetBindings();
            CheckedOut.ResetBindings();
            if (!ProgressBarForm.IsDisposed) {
                ProgressBarForm.Close();
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAwaitBroadcasts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            UpdateStatus("Disconnected from server!");
        }
    }
}
