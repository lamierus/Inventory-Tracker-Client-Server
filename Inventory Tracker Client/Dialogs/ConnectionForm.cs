using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Tracker_Client {
    public partial class ConnectionForm : Form {

        public string ReturnAddress { get; set; }
        public int ReturnRetries { get; set; }

        public ConnectionForm(string address) {
            InitializeComponent();
            tbAddress.Text = address;
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            //ReturnRetries = (int)cboxNumRetries.SelectedItem;
            ReturnRetries = 3;
            ReturnAddress = tbAddress.Text;
            Close();
        }

        private void ConnectionForm_Closing(object sender, FormClosingEventArgs e) {
            if (DialogResult != DialogResult.OK) {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
