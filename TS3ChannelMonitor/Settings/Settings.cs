using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS3ChannelMonitor.Settings
{
    class Settings
    {
        public TS3QueryInfo TS3Info { get; set; }

        public Settings()
        {
        }

        public Settings(TS3QueryInfo info)
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
