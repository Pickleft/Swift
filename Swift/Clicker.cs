using Swift.Mods;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Swift.Calls;

namespace Swift
{
    public partial class Clicker : Form
    {
        #region Properties
        private IntPtr javah;
        private bool leftlock;
        private bool blocks;
        private bool vermode;
        private bool foodorrod;
        private bool rightlock;
        public static Randomize random = new Randomize(Calls.RandomSeed);
        private readonly System.Timers.Timer randomizer = new System.Timers.Timer();
        private CancellationTokenSource CancelTokenLeft;
        private CancellationTokenSource CancelTokenRight;
        #endregion

        #region Constructor (.ctor)
        public Clicker()
        {
            Opacity = 0.95;
            randomizer.Elapsed += randomvent;
            InitializeComponent();
        }
        #endregion

        #region HotKeys
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                int id = m.WParam.ToInt32();
                if (id == 1)
                {
                    statusleft.Checked = !statusleft.Checked;
                }
                else if (id == 2)
                {
                    statusright.Checked = !statusright.Checked;
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region Clicker Modules
        private void Clickvent()
        {
            while (!CancelTokenLeft.IsCancellationRequested)
            {
                bool isclicking = (MouseButtons & MouseButtons.Left) > 0;
                switch (isclicking)
                {
                    case true:
                        Thread.Sleep(0); // // To improve preformance when clicking
                        break;
                    case false:
                        Thread.Sleep(1);// Consume less cpu usage when not clicking
                        break;
                }
                if (vermode)
                {
                    Core.Mode18(javah, leftlock, (int)leftcps).Wait();
                }
                else if (blocks)
                {
                    Core.breakblock(javah, leftlock, (int)leftcps).Wait();
                }
                else
                {

                    Core.leftclick(javah, leftlock, (int)leftcps).Wait();
                }
            }
        }


        private void RightClickvent()
        {
            while (!CancelTokenRight.IsCancellationRequested)
            {
                bool isclicking = (MouseButtons & MouseButtons.Right) > 0;
                switch (isclicking)
                {
                    case true:
                        Thread.Sleep(0); // To improve preformance when clicking
                        break;
                    case false:
                        Thread.Sleep(1);// Consume less cpu usage when not clicking
                        break;
                }
                switch (foodorrod)
                {
                    case true:
                        Core.rodorfoodlol(javah, rightlock, (int)rightcps).Wait();
                        break;
                    case false:
                        Core.rightclick(javah, rightlock, (int)rightcps).Wait();
                        break;
                }
            }
        }


        private void randomvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            randomizer.Interval = random.Rnd(500, 1000);
            int chance = random.Rnd(0, 100);
            if (chance < Calls.ChanceBoost)
            {
                int boost = random.Rnd(Calls.BoostMin, Calls.BoostMax);
                leftcps = 1000 / (cps + boost);
            }
            else
            {
                int drop = random.Rnd(Calls.DropMin, Calls.DropMax);
                leftcps = 1000 / (cps - drop);
            }
        }

        private void WindowFinder_Tick(object sender, EventArgs e)
        {
            javah = Guna.UI2.Native.WinApi.FindWindow("LWJGL", null);
        }
        #endregion

        #region Gui Control
        private void Home_Click(object sender, EventArgs e)
        {
            Hide();
            H.Location = Location;
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
            Refresh();
        }

        private void Preset_Click(object sender, EventArgs e)
        {
            Hide();
            P.Location = Location;
            P.Opacity = 0.3;
            P.Show();
            animate.Start();
        }

        private void destruct_Click(object sender, EventArgs e)
        {
            Hide();
            D.Location = Location;
            D.Opacity = 0.3;
            D.Show();
            animate.Start();
            KillService();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
        #endregion

        #region Properties Control
        private void colorSlider1_ValueChanged(object sender, EventArgs e)
        {
            /* cause i used timers i had to substract 2 from the value to accurate it */
            Lcps.Text = "Average Left CPS : " + (Lcpsslider.Value - 2).ToString();
            cps = (double)Lcpsslider.Value;
            leftcps = (double)(1000 / Lcpsslider.Value);
        }

        private void Randomize_CheckedChanged(object sender, EventArgs e)
        {
            randomizer.Enabled = Randomize.Checked;
        }

        private void blatant_CheckedChanged(object sender, EventArgs e)
        {
            Lcpsslider.Maximum = blatant.Checked ? 102 : 22;
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
            leftlock = lmblock.Checked;
        }

        private void blatantr_CheckedChanged(object sender, EventArgs e)
        {
            Rcpsslider.Maximum = blatantr.Checked ? 52 : 22;
        }
        private void statusleft_CheckedChanged(object sender, EventArgs e)
        {
            CancelTokenLeft = new CancellationTokenSource();
            if (statusleft.Checked)
            {
                new Task((Action) => Clickvent(), CancelTokenLeft.Token, TaskCreationOptions.LongRunning).Start();
            }
            else
            {
                CancelTokenLeft.Cancel();
            }
        }
        private void statusright_CheckedChanged(object sender, EventArgs e)
        {
            CancelTokenRight = new CancellationTokenSource();
            if (statusright.Checked)
            {
                new Task((Action) => RightClickvent(), CancelTokenRight.Token, TaskCreationOptions.LongRunning).Start();
            }
            else
            {
                CancelTokenRight.Cancel();
            }
        }

        private void rmblock_CheckedChanged(object sender, EventArgs e)
        {
            rightlock = rmblock.Checked;
        }

        private void food_CheckedChanged(object sender, EventArgs e)
        {
            foodorrod = food.Checked;
        }

        private void Rcpsslider_ValueChanged(object sender, EventArgs e)
        {
            Rcps.Text = "Average Right CPS : " + (Rcpsslider.Value - 2).ToString();
            _cps = (double)Rcpsslider.Value;
            rightcps = (double)(1000 / Rcpsslider.Value);
        }

        #endregion

        #region Key Bind Selector
        private void Bind_Click(object sender, EventArgs e)
        {
            Bind.Text = "[ ... ]";
            Bind.Checked = true;
        }

        private void rbind_Click(object sender, EventArgs e)
        {
            rbind.Text = "[ ... ]";
            rbind.Checked = true;
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
                    Calls.UnregisterHotKey(Handle, 1);
                    Keys key = e.KeyCode;
                    Calls.RegisterHotKey(Handle, 1, 0, (uint)key);
                }
                Bind.Checked = false;
            }
            else
            {
                return;
            }
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
                    Calls.UnregisterHotKey(Handle, 2);
                    Keys keyright = e.KeyCode;
                    Calls.RegisterHotKey(Handle, 2, 0, (uint)keyright);
                }
                rbind.Checked = false;
            }
            else
            {
                return;
            }
        }
        #endregion
    }
}
