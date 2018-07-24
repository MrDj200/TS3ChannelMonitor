using System;
using System.Collections.Generic;
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
            try
            {
                //TSClient.
                await TSClient.Connect();

                MessageBox.Show("Made it", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); // Debug

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

            switch (TS3Bot.Instance.Login(ts3ServerInfo).GetAwaiter().GetResult())
            {
                case ConnectionResult.OK:
                    Console.WriteLine("Connected!");
                    break;
                case ConnectionResult.SOCKET:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nCould not connect to TeamSpeak Server! Is the Server offline?\n\nPress Enter to exit");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                    return;
                //	break;
                case ConnectionResult.QUERY:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPlease Enter the correct Login Credentials! (" + SettingsFile + ")\n\nPress Enter to exit");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                    return;
                //	break;

                case ConnectionResult.UNKNOWN:
                default:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nCould not connect to TeamSpeak Server!\n\nPress Enter to exit");
                    MessageBox.Show("Could not connect to TeamSpeak Server!\n\nPress Enter to exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    //	break;
            }

            #region ThreadStuff
            Thread botThread = new Thread(RunBot);
            botThread.Start();
            #endregion
        }

        public static void RunBot()
        {
            TS3Bot myBot = TS3Bot.Instance;

            myBot.StartBot(myBot.VServerID).Wait();

            myBot.EventShit();

            CurrentClients = myBot.TSClient.GetClients().GetAwaiter().GetResult();

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
