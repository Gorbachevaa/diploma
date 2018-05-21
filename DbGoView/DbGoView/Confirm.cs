using MetroFramework.Controls;
using System.Windows.Forms;

namespace DbGoView
{
    public partial class Confirm : MetroFramework.Forms.MetroForm
    {
        public bool Result = false;
        public Confirm()
        {
            InitializeComponent();
        }

        private void metroYesButton_Click(object sender, System.EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void metroNoButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
