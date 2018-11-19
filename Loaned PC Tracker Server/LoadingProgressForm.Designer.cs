namespace Loaned_PC_Tracker_Server {
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
            components = new System.ComponentModel.Container();
            lblLoadingProgress = new System.Windows.Forms.Label();
            pbLoadingProgress = new System.Windows.Forms.ProgressBar();
            // 
            // lblLoadingProgress
            // 
            lblLoadingProgress.Dock = System.Windows.Forms.DockStyle.Top;
            lblLoadingProgress.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            lblLoadingProgress.Location = new System.Drawing.Point(0, 0);
            lblLoadingProgress.Name = "lblLoadingProgress";
            lblLoadingProgress.Size = new System.Drawing.Size(284, 23);
            lblLoadingProgress.TabIndex = 0;
            lblLoadingProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLoadingProgress
            // 
            pbLoadingProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            pbLoadingProgress.Location = new System.Drawing.Point(0, 12);
            pbLoadingProgress.Name = "pbLoadingProgress";
            pbLoadingProgress.Size = new System.Drawing.Size(284, 25);
            pbLoadingProgress.TabIndex = 1;
            // 
            // frmLoadingProgress
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(284, 37);
            ControlBox = false;
            Controls.Add(lblLoadingProgress);
            Controls.Add(pbLoadingProgress);
            Location = new System.Drawing.Point(25, 25);
            Name = "frmLoadingProgress";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion

        private System.Windows.Forms.ProgressBar pbLoadingProgress;
        private System.Windows.Forms.Label lblLoadingProgress;
    }
}