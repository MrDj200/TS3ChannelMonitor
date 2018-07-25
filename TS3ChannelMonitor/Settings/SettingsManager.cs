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
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        internal static void Save()
        {
            // TODO: Implement this
            throw new NotImplementedException();
        }
    }
}
