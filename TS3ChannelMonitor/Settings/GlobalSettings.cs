using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ChannelMonitor.Settings
{
    class GlobalSettings
    {
        public TS3QueryInfo TS3Info { get; set; }

        public GlobalSettings()
        {
            TS3Info = new TS3QueryInfo();
        }

        public GlobalSettings(TS3QueryInfo info)
        {
            try
            {
                this.TS3Info = info;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
