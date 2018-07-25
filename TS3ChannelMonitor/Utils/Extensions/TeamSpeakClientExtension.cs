using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpeak3QueryApi.Net;
using TeamSpeak3QueryApi.Net.Specialized;

namespace TS3ChannelMonitor.Utils.Extensions
{
    public static class TeamSpeakClientExtension
    {
        public static Task SendOfflineMessage(this TeamSpeakClient tsclient, String uid, String message, String subject = "Message from TS3Bot")
        {
            message = message ?? string.Empty;
            return tsclient.Client.
                Send("messageadd",
                new Parameter("cluid", uid),
                new Parameter("subject", subject),
                new Parameter("message", message));
        }

        public static String Quit(this TeamSpeakClient tsclient)
        {
            if(tsclient != null)
            {
                tsclient.Client.Send("quit");
                return "OK";
            }

            return "ERROR";            
        }
    }
}
