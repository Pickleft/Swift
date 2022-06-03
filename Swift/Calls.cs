using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swift
{
    internal class Calls
    {
        public static Form C = new Swift.Clicker();
        public static Form H = new Swift.Menu();
        public static Form P = new Swift.Presets();
        public static Form D = new Swift.Destructs();


        public static double cps { get; set; }
        public static double leftcps { get; set; }

        public static double _cps { get; set; }
        public static double rightcps { get; set; }

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        public static extern UInt32 DnsFlushResolverCache();

        public static void restartservice()
        {
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C sc start eventlog",
                FileName = "cmd.exe"
            });
        }

        public static void KillService()
        {
            ManagementObject wmiService = new ManagementObject("Win32_Service.Name='" + "EventLog" + "'");
            wmiService.Get();
            int id = Convert.ToInt32(wmiService["ProcessId"]);
            Process proces = Process.GetProcessById(id);
            proces.Kill();
        }
    }
}
