using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using static Swift.Calls;

namespace Swift
{
    public partial class Destructs : Form
    {
        #region Properties
        public List<string> preffiles = new List<string>();
        private bool delete;
        public uint dns;
        public List<string> tempfiles = new List<string>();
        #endregion

        #region Constructor .ctor
        public Destructs()
        {
            InitializeComponent();
        }
        #endregion

        #region GUI Controls
        private void Preset_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            Hide();
            P.Location = Location;
            P.Opacity = 0.3;
            P.Show();
            animate.Start();
        }

        private void clicker_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            Hide();
            C.Location = Location;
            C.Opacity = 0.3;
            C.Show();
            animate.Start();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            try { restartservice(); } catch { }
            Hide();
            H.Location = Location;
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


        private void Destructs_Load(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
        #endregion

        #region Destruct Methods
        private void usgl_CheckedChanged(object sender, EventArgs e)
        {
            usgl.Checked = true;
        }

        private void ClearPref_CheckedChanged(object sender, EventArgs e)
        {
            if (ClearPref.Checked)
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Prefetch";
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
            if (temp.Checked)
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp";
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
            dns = flushd.Checked ? 1 : (uint)0;
        }

        private void selfdel_CheckedChanged(object sender, EventArgs e)
        {
            delete = selfdel.Checked;
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            if (new ServiceController("EventLog").Status == ServiceControllerStatus.Stopped)
            {

                foreach (string file in tempfiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
                foreach (string file in preffiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }

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
                Close();
            }

        }
        #endregion
    }
}
