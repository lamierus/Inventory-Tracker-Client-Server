using System;
using System.Windows.Forms;

namespace Loaned_PC_Tracker_Client {
    public partial class Viewer : Form {
        public Viewer(Laptop PC) {
            InitializeComponent();

            tbBrand.Text = PC.Brand;
            tbLoanerNumber.Text = PC.Number.ToString();
            tbModel.Text = PC.Model;
            tbSerialNumber.Text = PC.Serial;
            tbTicketNumber.Text = PC.TicketNumber;
            tbTNumber.Text = PC.Username;
            tbUserPCSN.Text = PC.UserPCSerial;
            tbWarranty.Text = PC.Warranty;

            
        }
        
        private void btnOK_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
