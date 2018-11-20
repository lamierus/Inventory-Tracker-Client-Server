namespace Inventory_Tracker_Client {
    partial class InventoryClient {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bgwLoadSites = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadPCs = new System.ComponentModel.BackgroundWorker();
            this.bgwSaveChanges = new System.ComponentModel.BackgroundWorker();
            this.cbSiteChooser = new System.Windows.Forms.ComboBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblCheckedOut = new System.Windows.Forms.Label();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.splitDataGridViews = new System.Windows.Forms.SplitContainer();
            this.dgvCheckedOut = new System.Windows.Forms.DataGridView();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.rbHotSwaps = new System.Windows.Forms.RadioButton();
            this.rbLoaners = new System.Windows.Forms.RadioButton();
            this.rbHidden = new System.Windows.Forms.RadioButton();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSetDefaultSite = new System.Windows.Forms.Button();
            this.btnRemoveOld = new System.Windows.Forms.Button();
            this.btnEditPC = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.tbConnectionStatus = new System.Windows.Forms.TextBox();
            this.bgwAwaitBroadcasts = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitDataGridViews)).BeginInit();
            this.splitDataGridViews.Panel1.SuspendLayout();
            this.splitDataGridViews.Panel2.SuspendLayout();
            this.splitDataGridViews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedOut)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwLoadSites
            // 
            this.bgwLoadSites.WorkerReportsProgress = true;
            this.bgwLoadSites.WorkerSupportsCancellation = true;
            this.bgwLoadSites.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadSites_DoWork);
            this.bgwLoadSites.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwLoadSites_ProgressChanged);
            this.bgwLoadSites.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadSites_RunWorkerCompleted);
            // 
            // bgwLoadPCs
            // 
            this.bgwLoadPCs.WorkerReportsProgress = true;
            this.bgwLoadPCs.WorkerSupportsCancellation = true;
            // 
            // bgwSaveChanges
            // 
            this.bgwSaveChanges.WorkerReportsProgress = true;
            this.bgwSaveChanges.WorkerSupportsCancellation = true;
            // 
            // cbSiteChooser
            // 
            this.cbSiteChooser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSiteChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSiteChooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSiteChooser.FormattingEnabled = true;
            this.cbSiteChooser.Location = new System.Drawing.Point(266, 12);
            this.cbSiteChooser.Name = "cbSiteChooser";
            this.cbSiteChooser.Size = new System.Drawing.Size(200, 24);
            this.cbSiteChooser.TabIndex = 2;
            this.cbSiteChooser.SelectedIndexChanged += new System.EventHandler(this.cbSiteChooser_SelectedIndexChanged);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.Location = new System.Drawing.Point(78, 83);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(128, 18);
            this.lblAvailable.TabIndex = 3;
            this.lblAvailable.Text = "Currently Available";
            // 
            // lblCheckedOut
            // 
            this.lblCheckedOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckedOut.AutoSize = true;
            this.lblCheckedOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckedOut.Location = new System.Drawing.Point(542, 83);
            this.lblCheckedOut.Name = "lblCheckedOut";
            this.lblCheckedOut.Size = new System.Drawing.Size(95, 18);
            this.lblCheckedOut.TabIndex = 4;
            this.lblCheckedOut.Text = "Checked Out";
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.AllowUserToAddRows = false;
            this.dgvAvailable.AllowUserToDeleteRows = false;
            this.dgvAvailable.AllowUserToResizeRows = false;
            this.dgvAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAvailable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAvailable.Location = new System.Drawing.Point(3, 3);
            this.dgvAvailable.MultiSelect = false;
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.ReadOnly = true;
            this.dgvAvailable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAvailable.RowHeadersVisible = false;
            this.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailable.Size = new System.Drawing.Size(300, 310);
            this.dgvAvailable.TabIndex = 5;
            this.dgvAvailable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailable_CellClick);
            // 
            // splitDataGridViews
            // 
            this.splitDataGridViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitDataGridViews.Location = new System.Drawing.Point(12, 104);
            this.splitDataGridViews.Name = "splitDataGridViews";
            // 
            // splitDataGridViews.Panel1
            // 
            this.splitDataGridViews.Panel1.Controls.Add(this.dgvAvailable);
            // 
            // splitDataGridViews.Panel2
            // 
            this.splitDataGridViews.Panel2.Controls.Add(this.dgvCheckedOut);
            this.splitDataGridViews.Size = new System.Drawing.Size(712, 316);
            this.splitDataGridViews.SplitterDistance = 356;
            this.splitDataGridViews.SplitterWidth = 1;
            this.splitDataGridViews.TabIndex = 0;
            this.splitDataGridViews.TabStop = false;
            // 
            // dgvCheckedOut
            // 
            this.dgvCheckedOut.AllowUserToAddRows = false;
            this.dgvCheckedOut.AllowUserToDeleteRows = false;
            this.dgvCheckedOut.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgvCheckedOut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheckedOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCheckedOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCheckedOut.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCheckedOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckedOut.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCheckedOut.Location = new System.Drawing.Point(52, 4);
            this.dgvCheckedOut.MultiSelect = false;
            this.dgvCheckedOut.Name = "dgvCheckedOut";
            this.dgvCheckedOut.ReadOnly = true;
            this.dgvCheckedOut.RowHeadersVisible = false;
            this.dgvCheckedOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckedOut.Size = new System.Drawing.Size(300, 310);
            this.dgvCheckedOut.TabIndex = 6;
            this.dgvCheckedOut.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckedOut_CellClick);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Location = new System.Drawing.Point(340, 108);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(55, 50);
            this.btnCheckOut.TabIndex = 9;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // rbHotSwaps
            // 
            this.rbHotSwaps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbHotSwaps.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbHotSwaps.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbHotSwaps.Location = new System.Drawing.Point(376, 42);
            this.rbHotSwaps.Name = "rbHotSwaps";
            this.rbHotSwaps.Size = new System.Drawing.Size(90, 30);
            this.rbHotSwaps.TabIndex = 1;
            this.rbHotSwaps.Text = "Hot Swaps";
            this.rbHotSwaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbHotSwaps.UseVisualStyleBackColor = true;
            this.rbHotSwaps.CheckedChanged += new System.EventHandler(this.rbHotSwap_CheckedChanged);
            // 
            // rbLoaners
            // 
            this.rbLoaners.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbLoaners.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbLoaners.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbLoaners.Location = new System.Drawing.Point(266, 42);
            this.rbLoaners.Name = "rbLoaners";
            this.rbLoaners.Size = new System.Drawing.Size(90, 30);
            this.rbLoaners.TabIndex = 0;
            this.rbLoaners.Text = "Loaners";
            this.rbLoaners.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbLoaners.UseVisualStyleBackColor = true;
            this.rbLoaners.CheckedChanged += new System.EventHandler(this.rbLoaner_CheckedChanged);
            // 
            // rbHidden
            // 
            this.rbHidden.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbHidden.AutoSize = true;
            this.rbHidden.Checked = true;
            this.rbHidden.Location = new System.Drawing.Point(201, 49);
            this.rbHidden.Name = "rbHidden";
            this.rbHidden.Size = new System.Drawing.Size(59, 17);
            this.rbHidden.TabIndex = 7;
            this.rbHidden.TabStop = true;
            this.rbHidden.Text = "Hidden";
            this.rbHidden.UseVisualStyleBackColor = true;
            this.rbHidden.Visible = false;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Location = new System.Drawing.Point(340, 163);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(55, 50);
            this.btnCheckIn.TabIndex = 10;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddNew.Enabled = false;
            this.btnAddNew.Location = new System.Drawing.Point(340, 303);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(55, 50);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "Add New PC";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSetDefaultSite
            // 
            this.btnSetDefaultSite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetDefaultSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDefaultSite.Location = new System.Drawing.Point(475, 15);
            this.btnSetDefaultSite.Name = "btnSetDefaultSite";
            this.btnSetDefaultSite.Size = new System.Drawing.Size(80, 20);
            this.btnSetDefaultSite.TabIndex = 12;
            this.btnSetDefaultSite.Text = "Set Default";
            this.btnSetDefaultSite.UseVisualStyleBackColor = true;
            this.btnSetDefaultSite.Click += new System.EventHandler(this.btnSetDefaultSite_Click);
            // 
            // btnRemoveOld
            // 
            this.btnRemoveOld.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveOld.Enabled = false;
            this.btnRemoveOld.Location = new System.Drawing.Point(340, 358);
            this.btnRemoveOld.Name = "btnRemoveOld";
            this.btnRemoveOld.Size = new System.Drawing.Size(55, 50);
            this.btnRemoveOld.TabIndex = 13;
            this.btnRemoveOld.Text = "Remove Old PC";
            this.btnRemoveOld.UseVisualStyleBackColor = true;
            this.btnRemoveOld.Click += new System.EventHandler(this.btnRemoveOld_Click);
            // 
            // btnEditPC
            // 
            this.btnEditPC.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditPC.Enabled = false;
            this.btnEditPC.Location = new System.Drawing.Point(340, 248);
            this.btnEditPC.Name = "btnEditPC";
            this.btnEditPC.Size = new System.Drawing.Size(55, 50);
            this.btnEditPC.TabIndex = 14;
            this.btnEditPC.Text = "Edit PC Info";
            this.btnEditPC.UseVisualStyleBackColor = true;
            this.btnEditPC.Click += new System.EventHandler(this.btnEditPC_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.Location = new System.Drawing.Point(266, 438);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(200, 23);
            this.btnSaveChanges.TabIndex = 15;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            // 
            // tbConnectionStatus
            // 
            this.tbConnectionStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbConnectionStatus.Location = new System.Drawing.Point(15, 12);
            this.tbConnectionStatus.Multiline = true;
            this.tbConnectionStatus.Name = "tbConnectionStatus";
            this.tbConnectionStatus.ReadOnly = true;
            this.tbConnectionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnectionStatus.Size = new System.Drawing.Size(245, 68);
            this.tbConnectionStatus.TabIndex = 16;
            // 
            // bgwAwaitBroadcasts
            // 
            this.bgwAwaitBroadcasts.WorkerReportsProgress = true;
            this.bgwAwaitBroadcasts.WorkerSupportsCancellation = true;
            this.bgwAwaitBroadcasts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAwaitBroadcasts_DoWork);
            this.bgwAwaitBroadcasts.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAwaitBroadcasts_ProgressChanged);
            this.bgwAwaitBroadcasts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAwaitBroadcasts_RunWorkerCompleted);
            // 
            // PCTrackerClient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(734, 472);
            this.Controls.Add(this.tbConnectionStatus);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnEditPC);
            this.Controls.Add(this.btnRemoveOld);
            this.Controls.Add(this.btnSetDefaultSite);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.lblCheckedOut);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.cbSiteChooser);
            this.Controls.Add(this.rbHotSwaps);
            this.Controls.Add(this.rbLoaners);
            this.Controls.Add(this.rbHidden);
            this.Controls.Add(this.splitDataGridViews);
            this.MinimumSize = new System.Drawing.Size(616, 438);
            this.Name = "PCTrackerClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loaned PC Tracker";
            this.Activated += new System.EventHandler(this.frmTracker_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPCTracker_Closing);
            this.Resize += new System.EventHandler(this.frmTracker_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.splitDataGridViews.Panel1.ResumeLayout(false);
            this.splitDataGridViews.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDataGridViews)).EndInit();
            this.splitDataGridViews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetDefaultSite;
        private System.Windows.Forms.ComboBox cbSiteChooser;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblCheckedOut;
        private System.Windows.Forms.DataGridView dgvAvailable;
        private System.Windows.Forms.DataGridView dgvCheckedOut;
        private System.Windows.Forms.RadioButton rbHotSwaps;
        private System.Windows.Forms.RadioButton rbLoaners;
        private System.Windows.Forms.RadioButton rbHidden;
        private System.Windows.Forms.SplitContainer splitDataGridViews;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnRemoveOld;
        private System.Windows.Forms.Button btnEditPC;
        private System.Windows.Forms.Button btnSaveChanges;

        private System.ComponentModel.BackgroundWorker bgwLoadSites;
        private System.ComponentModel.BackgroundWorker bgwLoadPCs;
        private System.ComponentModel.BackgroundWorker bgwSaveChanges;
        private System.Windows.Forms.TextBox tbConnectionStatus;
        private System.ComponentModel.BackgroundWorker bgwAwaitBroadcasts;
    }
}

