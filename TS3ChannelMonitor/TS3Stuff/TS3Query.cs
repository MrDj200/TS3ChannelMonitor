using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TeamSpeak3QueryApi.Net.Specialized;
using TeamSpeak3QueryApi.Net.Specialized.Responses;
using TS3ChannelMonitor.Settings;
using static TS3ChannelMonitor.Program;

namespace TS3ChannelMonitor.TS3Stuff
{
    class TS3Query
    {
        public String Name { get; set; } = "GameBot by MrDj";
        public String Server { get; set; } = "127.0.0.1";
        private String LoginName { get; set; } = "serveradmin";
        private String LoginPass { get; set; } = "OY3pSQF4";

        public TeamSpeakClient TSClient { get; private set; }
        public int VServerID { get; private set; }

        public WhoAmI Who { get; private set; }

        public static TS3Query Instance { get; } = new TS3Query();

        private TS3Query()
        {

        }

        public async Task<ConnectionResult> Login(TS3QueryInfo info) => await Login(info.TS3LoginName, info.TS3LoginPass, info.ServerAddress, info.VirtualServerID);

        public async Task<ConnectionResult> Login(String LoginName, String LoginPass, String Server, int VServerID = 1)
        {
            TSClient = new TeamSpeakClient(Server);
            this.VServerID = VServerID;
            try
            {
                await TSClient.Connect();

                await TSClient.Login(LoginName, LoginPass);
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

    }
}
