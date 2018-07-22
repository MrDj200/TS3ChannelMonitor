using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS3ChannelMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            if (Program.SETTINGS != null)
            {
                this.queryServerBox.Text = Program.SETTINGS.TS3Info.ServerAddress;
                this.queryUserBox.Text = Program.SETTINGS.TS3Info.TS3LoginName;
                this.queryPassBox.Text = Program.SETTINGS.TS3Info.TS3LoginPass;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
