using System;
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
        public int idofL = 1;
        public int idofR = 2;
        System.Timers.Timer clicker = new System.Timers.Timer();
        System.Timers.Timer rightclicker = new System.Timers.Timer();
        System.Timers.Timer randomizer = new System.Timers.Timer();


        public Clicker()
        {
            this.Opacity = 0.95;
            clicker.Elapsed += Clickvent;
            rightclicker.Elapsed += RightClickvent;
            randomizer.Elapsed += randomvent;
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (Bind.Text != "[ Bind ]")
                {
                    if (Bind.Text != "[ ... ]")
                    {
                        Calls.UnregisterHotKey(Handle, idofL);
                        Keys key = (Keys)new KeysConverter().ConvertFromString(Bind.Text.Trim('[', ']', ' '));
                        Calls.RegisterHotKey(Handle, 1, 0, (uint)key);
                    }
                }
                if (rbind.Text != "[ Bind ]")
                {
                    if (rbind.Text != "[ ... ]")
                    {
                        Calls.UnregisterHotKey(Handle, idofR);
                        Keys keyright = (Keys)new KeysConverter().ConvertFromString(rbind.Text.Trim('[', ']', ' '));
                        Calls.RegisterHotKey(Handle, 2, 0, (uint)keyright);
                    }
                }
                if (m.Msg == 0x312)
                {
                    int id = m.WParam.ToInt32();
                    if (id == 1)
                    {
                        if (clicker.Enabled == true)
                        {
                            clicker.Enabled = false;
                            statusleft.Checked = false;
                        }
                        else
                        {
                            clicker.Enabled = true;
                            statusleft.Checked = true;

                        }
                    }
                    else if (id == 2)
                    {
                        if (rightclicker.Enabled == true)
                        {
                            rightclicker.Enabled = false;
                            statusright.Checked = false;
                        }
                        else
                        {
                            rightclicker.Enabled = true;
                            statusright.Checked = true;
                        }
                    }
                }
            }
            catch
            {

            }
            base.WndProc(ref m);
        }


        private void Clickvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            clicker.Interval = leftcps;
            Process[] processes = Process.GetProcesses();
            foreach (Process pList in processes)
            {
                if (pList.ProcessName.Contains("javaw") || pList.ProcessName.Contains("java")) // fixed typo
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

        public static Randomize random = new Randomize(Calls.RandomSeed);

        private void randomvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            randomizer.Interval = random.Rnd(500, 750);
            int chance = random.Rnd(0, 100);
            if (chance < Calls.ChanceBoost)
            {
                int boost = random.Rnd(Calls.BoostMin, Calls.BoostMax);
                leftcps = 1000 / (cps + boost);
            }
            else
            {
                int drop = random.Rnd(Calls.DropMin, Calls.DropMax);
                leftcps = 1000 / (cps + drop);
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
            Bind.Checked = true;
        }

        private void Bind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Bind.Checked)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Bind.Text = "[ Bind ]";
                }
                else
                {
                    Bind.Text = $"[ {e.KeyCode} ]";
                }
                Bind.Checked = false;
            }
            else
            {
                return;
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
            if (blatantr.Checked)
            {
                Rcpsslider.Maximum = 52;
            }
            else
            {
                Rcpsslider.Maximum = 22;
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
            rbind.Checked = true;
        }

        private void Rcpsslider_ValueChanged(object sender, EventArgs e)
        {
            Rcps.Text = "Average Right CPS : " + (Rcpsslider.Value - 2).ToString();
            _cps = (double)Rcpsslider.Value;
            rightcps = (double)(1000 / Rcpsslider.Value);
        }

        private void rbind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (rbind.Checked)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    rbind.Text = "[ Bind ]";
                }
                else
                {
                    rbind.Text = $"[ {e.KeyCode} ]";
                }
                rbind.Checked = false;
            }
            else
            {
                return;
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
    }
}
