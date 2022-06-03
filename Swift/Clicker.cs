using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Swift.Calls;
using Swift.Mods;
using System.Diagnostics;

namespace Swift
{
    public partial class Clicker : Form
    {

        /* removed shift disable and double click cause i am a lazy fuck, code it yourself. 
        the keyregister thing overrides so don't cry about it
        randomizatin is prt decent unless you got better make a pull request or something in github
        */
        IntPtr javah;
        bool leftlock;
        bool blocks;
        bool vermode;
        bool foodorrod;
        bool rightlock;
        public int idofL;
        public int idofR;
        System.Timers.Timer clicker = new System.Timers.Timer();
        System.Timers.Timer rightclicker = new System.Timers.Timer();
        System.Timers.Timer randomizer = new System.Timers.Timer();
        System.Timers.Timer drop = new System.Timers.Timer();
        System.Timers.Timer keyreg = new System.Timers.Timer();


        public Clicker()
        {
            this.Opacity = 0.95;
            clicker.Elapsed += Clickvent;
            rightclicker.Elapsed += RightClickvent;
            randomizer.Elapsed += randomvent;
            drop.Elapsed += dropvent;
            keyreg.Elapsed += keysevent;
            keyreg.Enabled = true;
            InitializeComponent();
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
        }

        public void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            try
            {
                if (Bind.Text != "[ Bind ]")
                {
                    if (Bind.Text != "[ ... ]")
                    {
                        Keys key = (Keys)new KeysConverter().ConvertFromString(Bind.Text.Trim('[', ']', ' '));
                        if (e.Key == key)
                        {
                            if (clicker.Enabled == true)
                            {
                                clicker.Enabled = false;
                                if (statusleft.InvokeRequired)
                                {
                                    statusleft.Invoke(new MethodInvoker(delegate { statusleft.Checked = false; }));
                                }
                            }
                            else
                            {
                                clicker.Enabled = true;
                                if (statusleft.InvokeRequired)
                                {
                                    statusleft.Invoke(new MethodInvoker(delegate { statusleft.Checked = true; }));
                                }

                            }
                        }
                    }
                }
                if (rbind.Text != "[ Bind ]")
                {
                    if (rbind.Text != "[ ... ]")
                    {
                        Keys keyright = (Keys)new KeysConverter().ConvertFromString(rbind.Text.Trim('[', ']', ' '));
                        if (e.Key == keyright)
                        {
                            if (rightclicker.Enabled == true)
                            {
                                rightclicker.Enabled = false;
                                if (statusright.InvokeRequired)
                                {
                                    statusright.Invoke(new MethodInvoker(delegate { statusright.Checked = false; }));
                                }
                            }
                            else
                            {
                                rightclicker.Enabled = true;
                                if (statusright.InvokeRequired)
                                {
                                    statusright.Invoke(new MethodInvoker(delegate { statusright.Checked = true; }));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void Clickvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            clicker.Interval = leftcps;
            Process[] processes = Process.GetProcesses();
            foreach (Process pList in processes)
            {
                if (pList.ProcessName.Contains("javaw") || pList.ProcessName.Contains("javah"))
                {
                    javah = pList.MainWindowHandle;
                }
            }
            if (vermode)
            {
                Core.Mode18(javah, leftlock);
            }
            else if (blocks)
            {
                Core.breakblock(javah, leftlock);
            }
            else
            {
                Core.leftclick(javah, leftlock);
            }

        }
        private void RightClickvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            rightclicker.Interval = rightcps;
            Process[] processes = Process.GetProcesses();
            foreach (Process pList in processes)
            {
                if (pList.ProcessName.Contains("javaw"))
                {
                    javah = pList.MainWindowHandle;
                }
            }
            if (foodorrod)
            {
                Core.rodorfoodlol(javah, rightlock);
            }
            else
            {
                Core.rightclick(javah, rightlock);
            }
        }

        private void keysevent(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (Bind.Text != "[ Bind ]")
                {
                    if (Bind.Text != "[ ... ]")
                    {
                        HotKeyManager.UnregisterHotKey(idofL);
                        Keys key = (Keys)new KeysConverter().ConvertFromString(Bind.Text.Trim('[', ']', ' '));
                        idofL = HotKeyManager.RegisterHotKey(key, KeyModifiers.NoRepeat);
                    }
                }
                if (rbind.Text != "[ Bind ]")
                {
                    if (rbind.Text != "[ ... ]")
                    {
                        HotKeyManager.UnregisterHotKey(idofR);
                        Keys keyright = (Keys)new KeysConverter().ConvertFromString(rbind.Text.Trim('[', ']', ' '));
                        idofR = HotKeyManager.RegisterHotKey(keyright, KeyModifiers.NoRepeat);
                    }
                }
            }
            catch
            {

            }
        }


        private void randomvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            double randominterval = leftcps + new Random().Next(250, 500);
            randomizer.Interval = randominterval;
            int randomint = new Random().Next(-3, 12);
            double rndcps = Mods.Randomize.rnddouble(randomint);
            leftcps = 1000 / (cps - rndcps);
        }

        private void dropvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cpsdrop.Checked)
            {
                double randominterval = new Random().Next(500, 1500);
                drop.Interval = randominterval;
                int randomcps = new Random().Next(-2, 4);
                leftcps = 1000 / (cps - randomcps);
            }
            if (cpsdropright.Checked)
            {
                double randominterval = new Random().Next(500, 1500);
                drop.Interval = randominterval;
                int randomcps = new Random().Next(-2, 4);
                rightcps = 1000 / (_cps - randomcps);
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            H.Location = this.Location;
            H.Opacity = 0.3;
            H.Show();
            animate.Start();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Home.Checked = false;
            guna2Button1.Checked = true;
            Preset.Checked = false;
        }

        private void animate_Tick(object sender, EventArgs e)
        {
            if (H.Visible == true)
            {
                H.Opacity += 0.05;
                guna2Button1.Checked = true;
                Home.Checked = false;
                if (H.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (P.Visible)
            {
                P.Opacity += 0.05;
                guna2Button1.Checked = true;
                Preset.Checked = false;
                if (P.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (D.Visible)
            {
                D.Opacity += 0.05;
                destruct.Checked = false;
                guna2Button1.Checked = true;
                if (D.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
        }

        private void Clicker_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void colorSlider1_ValueChanged(object sender, EventArgs e)
        {
            /* cause i used timers i had to substract 2 from the value to accurate it */
            Lcps.Text = "Average Left CPS : " + (Lcpsslider.Value - 2).ToString();
            cps = (double)Lcpsslider.Value;
            leftcps = (double)(1000 / Lcpsslider.Value);
        }

        private void Randomize_CheckedChanged(object sender, EventArgs e)
        {
            if (Randomize.Checked)
            {
                randomizer.Enabled = true;
            }
            else
            {
                randomizer.Enabled = false;
            }
        }


        private void blatant_CheckedChanged(object sender, EventArgs e)
        {
            if (blatant.Checked)
            {
                Lcpsslider.Maximum = 52;
            }
            else
            {
                Lcpsslider.Maximum = 22;
            }
        }
        private void breakblock_CheckedChanged(object sender, EventArgs e)
        {
            if (breakblock.Checked)
            {
                blocks = true;
                mode.Checked = false;
            }
            else
            {
                blocks = false;
            }
        }

       
        private void cpsdrop_CheckedChanged(object sender, EventArgs e)
        {
            if (cpsdrop.Checked)
            {
                drop.Enabled = true;
            }
            else
            {
                drop.Enabled = false;
            }
        }
        private void mode_CheckedChanged(object sender, EventArgs e)
        {
            if (mode.Checked)
            {
                vermode = true;
                breakblock.Checked = false;
            }
            else
            {
                vermode = false;
            }
        }

        private void lmblock_CheckedChanged(object sender, EventArgs e)
        {
            if (lmblock.Checked)
            {
                leftlock = true;
            }
            else
            {
                leftlock = false;
            }
        }

        private void Bind_Click(object sender, EventArgs e)
        {
            Bind.Text = "[ ... ]";
        }

        private void Bind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Bind.Text = "[ Bind ]";
            }
            else
            {
                Bind.Text = $"[ {e.KeyCode} ]";
            }
        }

        private void statusleft_CheckedChanged(object sender, EventArgs e)
        {
            if (statusleft.Checked)
            {
                clicker.Enabled = true;
            }
            else
            {
                clicker.Enabled = false;
            }
        }

        private void Clicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void blatantr_CheckedChanged(object sender, EventArgs e)
        {
            if (blatant.Checked)
            {
                Lcpsslider.Maximum = 52;
            }
            else
            {
                Lcpsslider.Maximum = 22;
            }
        }

        private void statusright_CheckedChanged(object sender, EventArgs e)
        {
            if (statusright.Checked)
            {
                rightclicker.Enabled = true;
            }
            else
            {
                rightclicker.Enabled = false;
            }
        }

        private void rmblock_CheckedChanged(object sender, EventArgs e)
        {
            if (rmblock.Checked)
            {
                rightlock = true;
            }
            else
            {
                rightlock = false;
            }
        }

        private void cpsdropright_CheckedChanged(object sender, EventArgs e)
        {
            if (cpsdropright.Checked)
            {
                drop.Enabled = true;
            }
            else
            {
                drop.Enabled = false;
            }
        }

        private void food_CheckedChanged(object sender, EventArgs e)
        {
            if (food.Checked)
            {
                foodorrod = true;
            }
            else
            {
                foodorrod = false;
            }
        }

        private void rbind_Click(object sender, EventArgs e)
        {
            rbind.Text = "[ ... ]";
        }

        private void Rcpsslider_ValueChanged(object sender, EventArgs e)
        {
            Rcps.Text = "Average Right CPS : " + (Rcpsslider.Value - 2).ToString();
            _cps = (double)Rcpsslider.Value;
            rightcps = (double)(1000 / Rcpsslider.Value);
        }

        private void rbind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rbind.Text = "[ Bind ]";
            }
            else
            {
                rbind.Text = $"[ {e.KeyCode} ]";
            }
        }

        private void Preset_Click(object sender, EventArgs e)
        {
            this.Hide();
            P.Location = this.Location;
            P.Opacity = 0.3;
            P.Show();
            animate.Start();
        }

        private void destruct_Click(object sender, EventArgs e)
        {
            this.Hide();
            D.Location = this.Location;
            D.Opacity = 0.3;
            D.Show();
            animate.Start();
            KillService();
        }

        private void mmc_Click(object sender, EventArgs e)
        {
            Randomize.Checked = Presets.rndchech;
            Lcpsslider.Value = Presets.sliderv;
            cpsdrop.Checked = Presets.cpsdcheck;
            //lol
        }
    }
}
