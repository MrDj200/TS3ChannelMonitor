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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Making the Window a fixed size
            // Removing the Maximize and Minimize Buttons, because the shit is not scaled...
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
        }
    }
}
