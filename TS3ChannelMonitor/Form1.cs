using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Responses;
using TS3ChannelMonitor.Settings;
using TS3ChannelMonitor.TS3Stuff;

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

        public void ChangeConnectLabel(bool connected)
        {
            if (connected)
            {
                this.statusLabel.Text = "Connected";
                this.statusLabel.ForeColor = Color.Green;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();

            lf.ShowDialog();
        }

        internal void FillChannelList(IReadOnlyList<GetChannelListInfo> channels)
        {
            ListViewItem item;
            foreach (GetChannelListInfo channel in channels)
            {
                string maxClients = channel.MaxClients.ToString();
                if(maxClients == "0")
                {
                    maxClients = "∞";
                }
                item = new ListViewItem(new[] { channel.Name, $"{channel.TotalClients}" });
                this.channelList.Items.Add(item);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Clearing the list on new Searches 
            foreach (ListViewItem item in this.channelList.Items)
            {
                this.channelList.Items.Remove(item);
            }

            IReadOnlyList<GetChannelListInfo> channels = TS3Bot.Instance.TSClient.GetChannels().GetAwaiter().GetResult();

            channels = (IReadOnlyList<GetChannelListInfo>)channels.Where(c => c.Name.Contains(this.txtSearchBar.Text));

        }
    }
}
