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


namespace Swift
{
    public partial class Presets : Form
    {
        public Presets()
        {
            InitializeComponent();
            this.Opacity = 0.95;
        }

        public static decimal sliderv { get; set; } = 15;
        public static bool rndchech { get; set; } = false;
        public static bool cpsdcheck { get; set; } = false;

        private void animate_Tick(object sender, EventArgs e)
        {
            if (C.Visible)
            {
                C.Opacity += 0.05;
                clicker.Checked = false;
                Preset.Checked = true;
                if (C.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (H.Visible)
            {
                H.Opacity += 0.05;
                Home.Checked = false;
                Preset.Checked = true;
                if (H.Opacity >= 0.95)
                {
                    animate.Stop();
                }
            }
            else if (D.Visible)
            {
                D.Opacity += 0.05;
                destruct.Checked = false;
                Preset.Checked = true;
                if (D.Opacity >= 0.95)
                {
                    animate.Stop();
                }
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

        private void clicker_Click(object sender, EventArgs e)
        {
            this.Hide();
            C.Location = this.Location;
            C.Opacity = 0.3;
            C.Show();
            animate.Start();
        }

        private void Preset_Click(object sender, EventArgs e)
        {
            Preset.Checked = true;
            Home.Checked = false;
            clicker.Checked = false;
        }

        private void Presets_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void mmc_Click(object sender, EventArgs e)
        {
            mmc.Checked = true;
            if (lunar.Checked)
            {
                lunar.Text = "Preset : Lunar";
                lunar.Width -= 60;
                lunar.Checked = false;
            }
            if (pvpland.Checked)
            {
                pvpland.Text = "Preset : PvP Land";
                pvpland.Width -= 60;
                pvpland.Checked = false;
            }
            if (mmc.Checked && mmc.Text.Contains("Loaded") == false)
            {
                mmc.Width += 60;
                mmc.Text += " | Loaded";
            }
            sliderv = 19;
            rndchech = true; /* missspelled check lol */
        }

        private void lunar_Click(object sender, EventArgs e)
        {
            lunar.Checked = true;
            if (mmc.Checked)
            {
                mmc.Text = "Preset : Minemen";
                mmc.Width -= 60;
                mmc.Checked = false;
            }
            if (pvpland.Checked)
            {
                pvpland.Text = "Preset : PvP Land";
                pvpland.Width -= 60;
                pvpland.Checked = false;
            }
            if (lunar.Checked && lunar.Text.Contains("Loaded") == false)
            {
                lunar.Width += 60;
                lunar.Text += " | Loaded";
            }
            sliderv = 19;
            rndchech = true;
            cpsdcheck = true;
        }

        private void pvpland_Click(object sender, EventArgs e)
        {
            pvpland.Checked = true;
            if (mmc.Checked)
            {
                mmc.Text = "Preset : Minemen";
                mmc.Width -= 60;
                mmc.Checked = false;
            }
            if (lunar.Checked)
            {
                lunar.Text = "Preset : Lunar";
                lunar.Width -= 60;
                lunar.Checked = false;
            }
            if (pvpland.Checked && pvpland.Text.Contains("Loaded") == false)
            {
                pvpland.Width += 60;
                pvpland.Text += " | Loaded";
            }
            sliderv = 21;
            rndchech = true;
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
    }
}
