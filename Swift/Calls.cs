﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Swift
{
    internal class Calls
    {
        #region Properties
        public static Form C = new Swift.Clicker();
        public static Form H = new Swift.Menu();
        public static Form P = new Swift.Presets();
        public static Form D = new Swift.Destructs();

        public static System.Drawing.Color current_color = System.Drawing.Color.FromArgb(255, 27, 45);
        public static double cps { get; set; } = 15;
        public static double leftcps { get; set; } = 1000 / 15;

        public static double _cps { get; set; }
        public static double rightcps { get; set; }

        public static uint ChanceBoost { get; set; }
        public static uint DropMax { get; set; }
        public static uint BoostMax { get; set; }
        public static uint DropMin { get; set; }
        public static uint BoostMin { get; set; }
        public static uint RandomSeed { get; set; }
        #endregion

        #region Methods
        public static void UpdateChart(System.Windows.Forms.DataVisualization.Charting.Chart chart1, Swift.Mods.Randomize randomise, dynamic chanceboost, dynamic boostmin, dynamic boostmax, dynamic dropmin, dynamic dropmax, dynamic cps)
        {
            double finalcps;
            int chance = randomise.Rnd(0, 100);
            if (chance < chanceboost)
            {
                int boost = randomise.Rnd(boostmin, boostmax);
                finalcps = 1000 / (cps + boost);
            }
            else
            {
                int drop = randomise.Rnd(dropmin, dropmax);
                finalcps = 1000 / (cps - drop);
            }
            int index = chart1.Series.FirstOrDefault().Points.AddY(1000 / finalcps);
            if (index > chart1.ChartAreas.FirstOrDefault().AxisX.Maximum)
            {
                chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = index - 25;
                chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = index;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        public static extern uint DnsFlushResolverCache();
        [DllImport("user32", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static void restartservice()
        {
            _ = Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C ping 192.168.1.1 -n 5 && sc start eventlog",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
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
        #endregion
    }
}
