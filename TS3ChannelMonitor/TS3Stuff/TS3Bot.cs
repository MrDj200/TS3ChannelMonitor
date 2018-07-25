using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Notifications;
using TeamSpeak3QueryApi.Net.Specialized.Responses;
using TS3ChannelMonitor.Settings;
using static TS3ChannelMonitor.Program;

namespace TS3ChannelMonitor.TS3Stuff
{
    class TS3Bot
    {
        public String Name { get; set; } = "TS3ChannelMonitor";
        public String Server { get; set; } = "127.0.0.1";
        private String LoginName { get; set; } = "serveradmin";
        private String LoginPass { get; set; } = "OY3pSQF4"; // This is for my local test TS3 server. Don't even try *looks @exp111*

        public static bool Running = true;

        public TeamSpeakClient TSClient { get; private set; }
        public int VServerID { get; private set; }

        public WhoAmI Who { get; private set; }
        public static TS3Bot Instance { get; } = new TS3Bot();
        public static IReadOnlyList<GetClientInfo> CurrentClients { get; private set; }

        private TS3Bot()
        {

        }

        public async Task<ConnectionResult> Login(TS3QueryInfo info) => await Login(info.TS3LoginName, info.TS3LoginPass, info.ServerAddress, info.VirtualServerID);

        public async Task<ConnectionResult> Login(String LoginName, String LoginPass, String Server, int VServerID = 1)
        {
            TSClient = new TeamSpeakClient(Server);
            this.VServerID = VServerID;
            if (this.VServerID == 0)
            {
                this.VServerID = 1;
            }
            
            try
            {
                //TSClient.
                await TSClient.Connect();

                await TSClient.Login(LoginName, LoginPass);
                await TSClient.UseServer(this.VServerID);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
                return ConnectionResult.SOCKET;
            }
            catch (TeamSpeak3QueryApi.Net.QueryException e)
            {
                Console.WriteLine(e.Error.Message);
                return ConnectionResult.QUERY;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ConnectionResult.UNKNOWN;
            }
            return ConnectionResult.OK;
        }

        public async Task StartBot(int sid)
        {
            await TSClient.UseServer(sid);
            await TSClient.ChangeNickName(this.Name);
            Who = await TSClient.WhoAmI();

            await TSClient.RegisterServerNotification();
            await TSClient.RegisterChannelNotification(Who.ChannelId);
            await TSClient.RegisterTextChannelNotification();
            await TSClient.RegisterTextPrivateNotification();
            await TSClient.RegisterTextServerNotification();
        }

        public void EventShit()
        {
            TSClient.Subscribe<TextMessage>(data =>
            {
                //CommandStuff.CommandManager.ExecuteCommand(data);
            });
        }

        public void GetClientsOnline()
        {
            //var shit = await GameBot.Instance.TSClient.GetClients();
            // TODO: this
        }

        public void StartConnection()
        {
            TS3QueryInfo ts3ServerInfo = SETTINGS.TS3Info;            

            #region ThreadStuff
            Thread botThread = new Thread(RunBot);
            botThread.Start();
            #endregion
        }

        public static void RunBot()
        {           
            TS3Bot myBot = TS3Bot.Instance;

            ConnectionResult result= myBot.Login(SETTINGS.TS3Info).GetAwaiter().GetResult();

            //MessageBox.Show($"{result.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            myBot.StartBot(1).Wait();

            myBot.EventShit();

            MainForm.Invoke((MethodInvoker) delegate {MainForm.ChangeConnectLabel(true);});

            // TODO: Find out how to do this shit :( (Change Label)
            //MainForm.ChangeConnectLabel(true);

            CurrentClients = myBot.TSClient.GetClients().GetAwaiter().GetResult();
            IReadOnlyList<GetChannelListInfo> channels = myBot.TSClient.GetChannels().GetAwaiter().GetResult();

            MainForm.Invoke((MethodInvoker)delegate { MainForm.FillChannelList(channels); });

            ulong i = 0;
            ulong refreshRate = 1000 / 20;

            while (Running)
            {

                if (i++ > refreshRate * 60)
                {
                    CurrentClients = myBot.TSClient.GetClients().GetAwaiter().GetResult();
                    i = 0;
                }

                Thread.Sleep(20);
            }
        }

        }
}
