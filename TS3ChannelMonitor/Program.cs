using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
