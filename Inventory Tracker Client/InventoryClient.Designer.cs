namespace Inventory_Tracker_Client {
    partial class InventoryUI {
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
            this.cbSiteChooser = new System.Windows.Forms.ComboBox();
            this.rbHotSwaps = new System.Windows.Forms.RadioButton();
            this.rbLoaners = new System.Windows.Forms.RadioButton();
            this.rbHidden = new System.Windows.Forms.RadioButton();
            this.btnSetDefaultSite = new System.Windows.Forms.Button();
            this.tbConnectionStatus = new System.Windows.Forms.TextBox();
            this.bgwAwaitBroadcasts = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
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
            this.cbSiteChooser.Location = new System.Drawing.Point(263, 47);
            this.cbSiteChooser.Name = "cbSiteChooser";
            this.cbSiteChooser.Size = new System.Drawing.Size(200, 24);
            this.cbSiteChooser.TabIndex = 2;
            this.cbSiteChooser.SelectedIndexChanged += new System.EventHandler(this.cbSiteChooser_SelectedIndexChanged);
            // 
            // rbHotSwaps
            // 
            this.rbHotSwaps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbHotSwaps.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbHotSwaps.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbHotSwaps.Location = new System.Drawing.Point(359, 77);
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
            this.rbLoaners.Location = new System.Drawing.Point(263, 77);
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
            this.rbHidden.Location = new System.Drawing.Point(198, 84);
            this.rbHidden.Name = "rbHidden";
            this.rbHidden.Size = new System.Drawing.Size(59, 17);
            this.rbHidden.TabIndex = 7;
            this.rbHidden.TabStop = true;
            this.rbHidden.Text = "Hidden";
            this.rbHidden.UseVisualStyleBackColor = true;
            this.rbHidden.Visible = false;
            // 
            // btnSetDefaultSite
            // 
            this.btnSetDefaultSite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetDefaultSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetDefaultSite.Location = new System.Drawing.Point(472, 50);
            this.btnSetDefaultSite.Name = "btnSetDefaultSite";
            this.btnSetDefaultSite.Size = new System.Drawing.Size(80, 20);
            this.btnSetDefaultSite.TabIndex = 12;
            this.btnSetDefaultSite.Text = "Set Default";
            this.btnSetDefaultSite.UseVisualStyleBackColor = true;
            this.btnSetDefaultSite.Click += new System.EventHandler(this.btnSetDefaultSite_Click);
            // 
            // tbConnectionStatus
            // 
            this.tbConnectionStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbConnectionStatus.Location = new System.Drawing.Point(12, 47);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 121);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 387);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(715, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // InventoryUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(747, 520);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbConnectionStatus);
            this.Controls.Add(this.btnSetDefaultSite);
            this.Controls.Add(this.cbSiteChooser);
            this.Controls.Add(this.rbHotSwaps);
            this.Controls.Add(this.rbLoaners);
            this.Controls.Add(this.rbHidden);
            this.MinimumSize = new System.Drawing.Size(616, 438);
            this.Name = "InventoryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loaned PC Tracker";
            this.Activated += new System.EventHandler(this.frmTracker_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPCTracker_Closing);
            this.Load += new System.EventHandler(this.InventoryUI_Load);
            this.Resize += new System.EventHandler(this.frmTracker_Resize);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetDefaultSite;
        private System.Windows.Forms.ComboBox cbSiteChooser;
        private System.Windows.Forms.RadioButton rbHotSwaps;
        private System.Windows.Forms.RadioButton rbLoaners;
        private System.Windows.Forms.RadioButton rbHidden;

        private System.ComponentModel.BackgroundWorker bgwLoadSites;
        private System.ComponentModel.BackgroundWorker bgwLoadPCs;
        private System.ComponentModel.BackgroundWorker bgwSaveChanges;
        private System.Windows.Forms.TextBox tbConnectionStatus;
        private System.ComponentModel.BackgroundWorker bgwAwaitBroadcasts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

