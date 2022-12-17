using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using static Swift.Calls;
using System.Reflection;

namespace Swift
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            guna2HtmlLabel4.Text = "Build N° : " + Assembly.GetExecutingAssembly().GetName().Version.Build;
            guna2HtmlLabel5.Text = "Version : " + Process.GetCurrentProcess().MainModule.FileVersionInfo.FileVersion;
            this.Opacity = 0.95;
        }

        private void discord_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/vTECNKcydU");
        }

        private void twitter_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://Twitter.com/Pickleft");
            
        }

        private void youtube_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://Youtube.com/Pickleft");
        }

        private void youtube_MouseHover(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Youtube";
            tt.SetToolTip(youtube, "Double Click to open Channel Link : Youtube.com/Pickleft");
        }

        private void discord_MouseHover(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Discord";
            tt.SetToolTip(discord, "Double Click to open Invite Link : Discord.gg/enDgttPKAW");
        }

        private void twitter_MouseHover(object sender, EventArgs e)
        {
            tt.ToolTipTitle = "Twitter";
            tt.SetToolTip(twitter, "Double Click to open Twitter Profile Link : Twitter.com/Pickleft");
        }
        private void clicker_Click(object sender, EventArgs e)
        {
            this.Hide();
            C.Location = this.Location;
            C.Opacity = 0.3;
            C.Show();
            animate.Start();
        }

        private void animate_Tick(object sender, EventArgs e)
        {
            if (C.Visible == true)
            {
                C.Opacity += 0.05;
                clicker.Checked = false;
                Home.Checked = true;
                if (C.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (P.Visible == true)
            {
                P.Opacity += 0.05;
                Preset.Checked = false;
                Home.Checked = true;
                if (P.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (D.Visible)
            {
                D.Opacity += 0.05;
                destruct.Checked = false;
                Home.Checked = true;
                if (D.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            clicker.Checked = false;
            Preset.Checked = false;
            Home.Checked = true;
        }

        private async void Menu_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.ForeColor = Color.White;
            this.Refresh();
            int i = 0;
            string title = "Swift.";
            string newtitle = "";
            for (; ; )
            {
                if (newtitle.Length >= title.Length)
                {
                    guna2HtmlLabel1.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel1.Text = guna2HtmlLabel1.Text.Insert(0, "★");
                    await Task.Delay(400);
                    newtitle = "";
                    i = 0;
                    guna2HtmlLabel1.ForeColor = Color.White;
                    guna2HtmlLabel2.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel2.ForeColor = Color.White;
                    guna2HtmlLabel3.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel3.ForeColor = Color.White;
                    guna2HtmlLabel4.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel4.ForeColor = Color.White;
                    guna2HtmlLabel5.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel5.ForeColor = Color.White;
                    guna2HtmlLabel6.ForeColor = current_color;
                    await Task.Delay(400);
                    guna2HtmlLabel6.ForeColor = Color.White;
                }
                else
                {
                    i += 1;
                    await Task.Delay(400);
                    guna2HtmlLabel1.Text = newtitle;
                    newtitle += title.ToCharArray()[i - 1];
                    guna2HtmlLabel1.ForeColor = Color.White;
                }
            }

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Presets_Click(object sender, EventArgs e)
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

        private void discord_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }
    }
}
