namespace Loaned_PC_Tracker_Client {
    partial class LoadingProgress {
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
            this.components = new System.ComponentModel.Container();
            this.lblLoadingProgress = new System.Windows.Forms.Label();
            this.pbLoadingProgress = new System.Windows.Forms.ProgressBar();
            // 
            // lblLoadingProgress
            // 
            this.lblLoadingProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoadingProgress.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblLoadingProgress.Location = new System.Drawing.Point(0, 0);
            this.lblLoadingProgress.Name = "lblLoadingProgress";
            this.lblLoadingProgress.Size = new System.Drawing.Size(284, 23);
            this.lblLoadingProgress.TabIndex = 0;
            this.lblLoadingProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLoadingProgress
            // 
            this.pbLoadingProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLoadingProgress.Location = new System.Drawing.Point(0, 12);
            this.pbLoadingProgress.Name = "pbLoadingProgress";
            this.pbLoadingProgress.Size = new System.Drawing.Size(284, 25);
            this.pbLoadingProgress.TabIndex = 1;
            // 
            // frmLoadingProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 37);
            this.ControlBox = false;
            this.Controls.Add(this.lblLoadingProgress);
            this.Controls.Add(this.pbLoadingProgress);
            this.Location = new System.Drawing.Point(25, 25);
            this.Name = "frmLoadingProgress";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion

        private System.Windows.Forms.ProgressBar pbLoadingProgress;
        private System.Windows.Forms.Label lblLoadingProgress;
    }
}