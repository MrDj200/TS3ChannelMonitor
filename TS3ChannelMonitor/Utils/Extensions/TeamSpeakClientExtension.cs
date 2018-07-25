using System;
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

        public static Task Quit(this TeamSpeakClient tsclient)
        {
            try
            {
                return tsclient.Client.Send("quit");
            }
            catch (Exception)
            {
                throw;
            }         
        }
    }
}
