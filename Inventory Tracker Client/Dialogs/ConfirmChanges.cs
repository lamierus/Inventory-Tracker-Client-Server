using System;
using System.Windows.Forms;

namespace Inventory_Tracker_Client {
    public partial class ConfirmChanges : Form {
        public ConfirmChanges() {
            InitializeComponent();
        }

        private void btnRevert_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
