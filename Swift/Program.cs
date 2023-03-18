using System;
using System.Windows.Forms;

namespace Swift
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Calls.KillService();
            Calls.H.FormClosed += FormClosed;
            Calls.C.FormClosed += FormClosed;
            Calls.D.FormClosed += FormClosed;
            Calls.P.FormClosed += FormClosed;
            Application.EnableVisualStyles();
            Application.Run(Calls.H);
        }

        private static void FormClosed(object sender, FormClosedEventArgs e)
        {
            Calls.restartservice();
            Environment.FailFast("Dll missing", new TypeLoadException());
        }
    }
}
