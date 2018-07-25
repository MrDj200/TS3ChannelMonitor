using System;
using System.Windows.Forms;

namespace TS3ChannelMonitor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit); // EventHandler when the Application is closed

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            // TODO: Gently exit TS3 Bot and all other Threads
        }

    }
}
