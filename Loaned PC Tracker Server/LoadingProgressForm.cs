using System.Windows.Forms;

namespace Loaned_PC_Tracker_Server {
    public partial class LoadingProgress : Form {

        public LoadingProgress(string message = "", int maxProgress = 100) {
            InitializeComponent();
            lblLoadingProgress.Text = message;
            pbLoadingProgress.Maximum = maxProgress;
        }

        public void setMessage(string message) {
            lblLoadingProgress.Text = message;
        }

        public string getMessage() {
            return lblLoadingProgress.Text;
        }

        public void setProgressMaximum(int maxProgress) {
            pbLoadingProgress.Maximum = maxProgress;
        }

        public int getProgressMaximum() {
            return pbLoadingProgress.Maximum;
        }

        public void updateProgress(int progressPercentage) {
            pbLoadingProgress.Value = progressPercentage;
        }
    }
}
