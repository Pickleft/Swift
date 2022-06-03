using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static Swift.Calls;
using System.Management;
using System.IO;
using System.Reflection;

namespace Swift
{
    public partial class Destructs : Form
    {
        public List<string> preffiles = new List<string>();
        bool delete;
        public uint dns;
        public List<string> tempfiles = new List<string>();
        public Destructs()
        {
            InitializeComponent();
        }
        private void Preset_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            this.Hide();
            P.Location = this.Location;
            P.Opacity = 0.3;
            P.Show();
            animate.Start();
        }

        private void clicker_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            this.Hide();
            C.Location = this.Location;
            C.Opacity = 0.3;
            C.Show();
            animate.Start();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            this.Hide();
            H.Location = this.Location;
            H.Opacity = 0.3;
            H.Show();
            animate.Start();
        }

        private void animate_Tick(object sender, EventArgs e)
        {
            if (C.Visible == true)
            {
                C.Opacity += 0.05;
                clicker.Checked = false;
                destruct.Checked = true;
                if (C.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (P.Visible == true)
            {
                P.Opacity += 0.05;
                Preset.Checked = false;
                destruct.Checked = true;
                if (P.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (H.Visible)
            {
                H.Opacity += 0.05;
                Home.Checked = false;
                destruct.Checked = true;
                if (H.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
        }

        private void usgl_CheckedChanged(object sender, EventArgs e)
        {
            usgl.Checked = true;
        }

        private void ClearPref_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearPref.Checked)
            {
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Prefetch";
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    if (file.ToLower().Contains(AppDomain.CurrentDomain.FriendlyName.ToLower()))
                    {
                        preffiles.Add(file);
                    }
                }
            }
            else
            {
                preffiles.Clear();
            }
        }

        private void temp_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearPref.Checked)
            {
                var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp";
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    tempfiles.Add(file);
                }
            }
            else
            {
                tempfiles.Clear();
            }
        }

        private void flushd_CheckedChanged(object sender, EventArgs e)
        {
            if (flushd.Checked)
            {
                dns = 1;
            }
            else
            {
                dns = 0;
            }
        }

        private void selfdel_CheckedChanged(object sender, EventArgs e)
        {
            if (selfdel.Checked)
            {
                delete = true;
            }
            else
            {
                delete = false;
            }
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            if (new ServiceController("EventLog").Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    foreach (var file in tempfiles)
                    {
                        File.Delete(file);
                    }
                    foreach (var file in preffiles)
                    {
                        File.Delete(file);
                    }
                }
                catch
                { }
                if (dns == 1)
                {
                    DnsFlushResolverCache();
                }
                if (delete)
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = "/C Ping 192.168.1.1 -n 5 & Del \"" + Application.ExecutablePath + "\"",
                        FileName = "cmd.exe",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    });
                }
                Environment.FailFast("Failed To Parse Int To An Array", new ArgumentException());
                restartservice();
            }

        }

        private void Destructs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Destructs_Load(object sender, EventArgs e)
        {
        }
    }
}
