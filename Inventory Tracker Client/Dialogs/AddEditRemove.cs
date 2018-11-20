using System;
using System.Windows.Forms;

namespace Inventory_Tracker_Client {
    public partial class AddEditRemove : Form {
        public Laptop ReturnPC = new Laptop();
        private bool Hotswap;
        private bool RemovePC;

        public AddEditRemove(bool hotswap = false) {
            InitializeComponent();

            Hotswap = hotswap;
            if (Hotswap) {
                //tbLoanerNumber.ReadOnly = true;
                //tbLoanerNumber.Text = string.Empty;
                lblLoanerNumber.Visible = false;
                tbLoanerNumber.Visible = false;
            }
        }

        public AddEditRemove(Laptop PCtoEdit, bool removePC, bool hotswap) {
            InitializeComponent();
            
            ReturnPC = PCtoEdit;
            Hotswap = hotswap;
            RemovePC = removePC;

            tbBrand.Text = ReturnPC.Brand;
            tbLoanerNumber.Text = ReturnPC.Number.ToString();
            tbModel.Text = ReturnPC.Model;
            tbSerialNumber.Text = ReturnPC.Serial;
            tbWarranty.Text = ReturnPC.Warranty;

            if (Hotswap) {
                //tbLoanerNumber.ReadOnly = true;
                //tbLoanerNumber.Text = string.Empty;
                lblLoanerNumber.Visible = false;
                tbLoanerNumber.Visible = false;
            }
            if (RemovePC) {
                btnAccept.Text = "Confirm";
                tbBrand.ReadOnly = true;
                tbLoanerNumber.ReadOnly = true;
                tbModel.ReadOnly = true;
                tbSerialNumber.ReadOnly = true;
                tbWarranty.ReadOnly = true;
                rtbWarning.Text += "WARNING:" + Environment.NewLine + "Confirmation will remove the PC from the list, permanently.";
                rtbWarning.Visible = true;
            }
        }

        private bool CheckIfFilledOut() {
            if (ReturnPC.Brand != null &&
                ReturnPC.Model != null &&
                ReturnPC.Serial != null &&
                ReturnPC.Warranty != null &&
                ((ReturnPC.Number > 0 && !Hotswap) || Hotswap)) {
                return true;
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (RemovePC) {
                DialogResult = DialogResult.OK;
                Close();
            } else if (CheckIfFilledOut()) {
                ReturnPC.CheckedOut = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            //todo: add error message popup that something isn't filled out.
        }

        private void tbLoanerNumber_TextChanged(object sender, EventArgs e) {
            int parsedNum;
            if(int.TryParse(tbLoanerNumber.Text, out parsedNum)) {
                ReturnPC.Number = parsedNum;
            } else {
                //todo: add an error message popup, if not a number
                tbLoanerNumber.ResetText();
            }
        }

        private void tbSerialNumber_TextChanged(object sender, EventArgs e) {
            TextBox sent = sender as TextBox;
            ReturnPC.Serial = sent.Text;
        }

        private void tbBrand_TextChanged(object sender, EventArgs e) {
            TextBox sent = sender as TextBox;
            ReturnPC.Brand = sent.Text;
        }

        private void tbModel_TextChanged(object sender, EventArgs e) {
            TextBox sent = sender as TextBox;
            ReturnPC.Model = sent.Text;
        }

        private void tbWarranty_TextChanged(object sender, EventArgs e) {
            TextBox sent = sender as TextBox;
            ReturnPC.Warranty = sent.Text;
        }
    }
}