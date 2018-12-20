namespace Inventory_Tracker_Client {
    partial class ViewEditPcs {
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
            this.bgwLoadSites = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadPCs = new System.ComponentModel.BackgroundWorker();
            this.bgwSaveChanges = new System.ComponentModel.BackgroundWorker();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnRemoveOld = new System.Windows.Forms.Button();
            this.btnEditPC = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.bgwAwaitBroadcasts = new System.ComponentModel.BackgroundWorker();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
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
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Location = new System.Drawing.Point(12, 12);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(55, 50);
            this.btnCheckOut.TabIndex = 9;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Location = new System.Drawing.Point(73, 12);
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
            this.btnAddNew.Location = new System.Drawing.Point(195, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(55, 50);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "Add New PC";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnRemoveOld
            // 
            this.btnRemoveOld.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveOld.Enabled = false;
            this.btnRemoveOld.Location = new System.Drawing.Point(256, 12);
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
            this.btnEditPC.Location = new System.Drawing.Point(134, 12);
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
            this.btnSaveChanges.Location = new System.Drawing.Point(317, 166);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(461, 23);
            this.btnSaveChanges.TabIndex = 15;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Visible = false;
            // 
            // bgwAwaitBroadcasts
            // 
            this.bgwAwaitBroadcasts.WorkerReportsProgress = true;
            this.bgwAwaitBroadcasts.WorkerSupportsCancellation = true;
            this.bgwAwaitBroadcasts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAwaitBroadcasts_DoWork);
            this.bgwAwaitBroadcasts.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAwaitBroadcasts_ProgressChanged);
            this.bgwAwaitBroadcasts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAwaitBroadcasts_RunWorkerCompleted);
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
            this.dgvAvailable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAvailable.Location = new System.Drawing.Point(12, 68);
            this.dgvAvailable.MultiSelect = false;
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.ReadOnly = true;
            this.dgvAvailable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAvailable.RowHeadersVisible = false;
            this.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailable.Size = new System.Drawing.Size(971, 546);
            this.dgvAvailable.TabIndex = 16;
            // 
            // ViewEditPcs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(995, 626);
            this.Controls.Add(this.dgvAvailable);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnEditPC);
            this.Controls.Add(this.btnRemoveOld);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.MinimumSize = new System.Drawing.Size(616, 438);
            this.Name = "ViewEditPcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loaned PC Tracker";
            this.Activated += new System.EventHandler(this.frmTracker_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPCTracker_Closing);
            this.Resize += new System.EventHandler(this.frmTracker_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnRemoveOld;
        private System.Windows.Forms.Button btnEditPC;
        private System.Windows.Forms.Button btnSaveChanges;

        private System.ComponentModel.BackgroundWorker bgwLoadSites;
        private System.ComponentModel.BackgroundWorker bgwLoadPCs;
        private System.ComponentModel.BackgroundWorker bgwSaveChanges;
        private System.ComponentModel.BackgroundWorker bgwAwaitBroadcasts;
        private System.Windows.Forms.DataGridView dgvAvailable;
    }
}

