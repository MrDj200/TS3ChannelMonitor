using System;
using System.Windows.Forms;

namespace TS3ChannelMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // TODO: Save Settings; Start Bot
            this.Close();
        }
    }
}
