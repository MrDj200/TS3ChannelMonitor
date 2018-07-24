﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamSpeak3QueryApi.Net.Specialized;
using TS3ChannelMonitor.Settings;
using TS3ChannelMonitor.Utils;

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
        public static GlobalSettings SETTINGS { get; set; }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {

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
            Application.Run(new Form1());
        }
    }
}
