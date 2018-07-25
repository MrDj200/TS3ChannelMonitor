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

namespace TS3ChannelMonitor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Making the Window a fixed size
            // Removing the Maximize and Minimize Buttons, because the shit is not scaled...
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public void ChangeConnectLabel(bool connected)
        {
            if (connected)
            {
                this.lblStatus.Text = "Connected";
                this.lblStatus.ForeColor = Color.Green;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            // TODO: Fill LoginForm textBoxes with saved Settings
            lf.ShowDialog();
            
        }
    }
}
