using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS3ChannelMonitor.Utils;

namespace TS3ChannelMonitor.Settings
{
    class SettingsManager
    {
        public static bool SettingsCheck(String filePath)
        {
            return File.Exists(filePath);
        }

        internal static void Save(GlobalSettings settings)
        {
            JsonSerialization.WriteToJsonFile<GlobalSettings>(Program.SettingsFile, settings);
        }
    }
}
