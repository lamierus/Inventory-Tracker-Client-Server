using System;
using System.Windows.Forms;

namespace Loaned_PC_Tracker_Client {
    public partial class CheckOutOrIn : Form {
        public Laptop ReturnPC { get; set; }
        private bool CheckedIn;
        private bool Hotswap;

        public CheckOutOrIn(Laptop PC, bool hotswap, bool checkIn = false) {
            InitializeComponent();

            Hotswap = hotswap;
            ReturnPC = PC;
            tbBrand.Text = ReturnPC.Brand;
            tbLoanerNumber.Text = ReturnPC.Number.ToString();
            tbModel.Text = ReturnPC.Model;
            tbSerialNumber.Text = ReturnPC.Serial;
            tbWarranty.Text = ReturnPC.Warranty;

            if (Hotswap) {
                lblLoanerNumber.Visible = false;
                tbLoanerNumber.Visible = false;
            } else {
                lblUserPCSerial.Visible = false;
                tbUserPCSerial.Visible = false;
            }

            if (checkIn) {
                CheckedIn = checkIn;
                btnAccept.Text = "Check In";
                tbTicketNumber.Text = ReturnPC.TicketNumber;
                tbTicketNumber.ReadOnly = true;
                tbTNumber.Text = ReturnPC.Username;
                tbTNumber.ReadOnly = true;
                tbUserPCSerial.Text = ReturnPC.UserPCSerial;
                tbUserPCSerial.ReadOnly = true;
            } else {
                btnAccept.Text = "Check Out";
            }
        }

        private void tbTicketNumber_TextChanged(object sender, EventArgs e) {
            ReturnPC.TicketNumber = tbTicketNumber.Text;
        }

        private void tbTNumber_TextChanged(object sender, EventArgs e) {
            ReturnPC.Username = tbTNumber.Text;
        }

        private void tbUserPCSerial_TextChanged(object sender, EventArgs e) {
            ReturnPC.UserPCSerial = tbUserPCSerial.Text;
        }

        private bool CheckIfFilledOut() {
            if (ReturnPC.Username != null && 
                ReturnPC.TicketNumber != null && 
                (ReturnPC.UserPCSerial != null || Hotswap) ) {
                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (CheckedIn) {
                ReturnPC.CheckedOut = false;
                ReturnPC.Username = "";
                ReturnPC.UserPCSerial = "";
                ReturnPC.TicketNumber = "";
                DialogResult = DialogResult.OK;
                Close();
            } else if (CheckIfFilledOut()) {
                ReturnPC.CheckedOut = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
