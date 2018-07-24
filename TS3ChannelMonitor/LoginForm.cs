using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS3ChannelMonitor.Settings;
using TS3ChannelMonitor.TS3Stuff;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(Program.SETTINGS == null)
            {
                Program.SETTINGS = new GlobalSettings();                
            }
            Program.SETTINGS.TS3Info.ServerAddress = this.queryServerBox.Text;
            Program.SETTINGS.TS3Info.TS3LoginName = this.queryUserBox.Text;
            Program.SETTINGS.TS3Info.TS3LoginPass = this.queryPassBox.Text;
            SettingsManager.Save(Program.SETTINGS);
            this.Close();
            TS3Bot.Instance.StartConnection();
        }
    }
}
