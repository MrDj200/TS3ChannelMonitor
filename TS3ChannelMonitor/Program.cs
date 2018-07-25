using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamSpeak3QueryApi.Net.Specialized;
using TS3ChannelMonitor.Settings;
using TS3ChannelMonitor.TS3Stuff;
using TS3ChannelMonitor.Utils;
using TS3ChannelMonitor.Utils.Extensions;

namespace TS3ChannelMonitor
{
    static class Program
    {
        public enum ConnectionResult
        {
            UNKNOWN = -1,
            OK = 0,
            SOCKET = 1,
            QUERY = 2,
            SQLERROR = 3
        }
        
        public static String SettingsFile { get; set; } = "Settings.json";

        public static Form1 MainForm { get; private set; }
        public static GlobalSettings SETTINGS { get; set; }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            if (SettingsManager.SettingsCheck(SettingsFile))
            {
                SETTINGS = JsonSerialization.ReadFromJsonFile<GlobalSettings>(SettingsFile);
            }
            else
            {
                SETTINGS = null;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            Application.Run(MainForm);

        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // When the application is exiting, write the application data to the
            // user file and close it.
            TS3Bot.Instance.TSClient.Quit();

            TS3Bot.Running = false;
        }

    }
}
