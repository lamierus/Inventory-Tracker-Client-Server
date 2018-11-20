namespace Inventory_Tracker_Client {
    partial class ConfirmChanges {
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
            this.lblChanges = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChanges
            // 
            this.lblChanges.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChanges.Location = new System.Drawing.Point(0, 0);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(284, 65);
            this.lblChanges.TabIndex = 0;
            this.lblChanges.Text = "Save your changes, before switching?";
            this.lblChanges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(172, 70);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 40);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(12, 70);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(100, 40);
            this.btnRevert.TabIndex = 2;
            this.btnRevert.Text = "Revert Changes And Switch";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // ConfirmChanges
            // 
            this.CancelButton = btnRevert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.ControlBox = false;
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.lblChanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ConfirmChanges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChanges;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnRevert;
    }
}