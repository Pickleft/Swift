using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using static Swift.Calls;

namespace Swift
{
    public partial class Presets : Form
    {
        // promised to release at a specific time no time to fix horrible config code.

        #region Properties
        private Mods.Randomize randomize;
        #endregion

        #region Constructor .ctor
        public Presets()
        {
            InitializeComponent();
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            BoostMax = (uint)boostmaxslider.Value;
            BoostMin = (uint)boostminslider.Value;
            RandomSeed = (uint)randomseedslider.Value;
            ChanceBoost = (uint)chanceboostslider.Value;
            DropMax = (uint)dropmaxslider.Value;
            DropMin = (uint)dropminslider.Value;
            Opacity = 0.95;
        }
        #endregion

        #region GUI Control
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
            Hide();
            H.Location = Location;
            H.Opacity = 0.3;
            H.Show();
            animate.Start();
        }

        private void clicker_Click(object sender, EventArgs e)
        {
            Hide();
            C.Location = Location;
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

        private void destruct_Click(object sender, EventArgs e)
        {
            Hide();
            D.Location = Location;
            D.Opacity = 0.3;
            D.Show();
            animate.Start();
            KillService();
        }

        private void CustomPresetButton_Click(object sender, EventArgs e)
        {
            paneluserinterface.Visible = false;
            CustomUIbutton.Checked = false;
            _presetpanel.Visible = CustomPresetButton.Checked;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Config Control
        private void apply_Click(object sender, EventArgs e)
        {
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
            randomize = new Mods.Randomize(RandomSeed);
            timer1.Enabled = !timer1.Enabled;
        }

        private void boostmaxslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            BoostMax = (uint)boostmaxslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
        }

        private void boostminslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            BoostMin = (uint)boostminslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
        }

        private void randomseedslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            RandomSeed = (uint)randomseedslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
            Clicker.random = new Mods.Randomize(Calls.RandomSeed);
        }

        private void chanceboostslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            ChanceBoost = (uint)chanceboostslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
        }

        private void dropmaxslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            DropMax = (uint)dropmaxslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
        }

        private void dropminslider_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = $"Stats : \nBoost Max : {boostmaxslider.Value}\nDrop Max : {dropmaxslider.Value}\nBoost Min : {boostminslider.Value}\nDrop Min : {dropminslider.Value}\nChance Boost : {chanceboostslider.Value}%\nChance Drop : {100 - chanceboostslider.Value}\nRandom Seed : {randomseedslider.Value}";
            DropMin = (uint)dropminslider.Value;
            chart1.Series.FirstOrDefault().Points.Clear();
            chart1.ChartAreas.FirstOrDefault().AxisX.Maximum = 25;
            chart1.ChartAreas.FirstOrDefault().AxisX.Minimum = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChart(chart1, randomize, ChanceBoost, BoostMin, BoostMax, DropMin, DropMax, Calls.cps - 2);
        }
        #endregion

        #region Custom UI Control
        private void CustomUIbutton_Click(object sender, EventArgs e)
        {
            _presetpanel.Visible = false;
            CustomPresetButton.Checked = false;
            paneluserinterface.Visible = CustomUIbutton.Checked;
        }



        private void green_slider_Scroll(object sender, ScrollEventArgs e)
        {
            previewpanel.BackColor = System.Drawing.Color.FromArgb((int)red_slider.Value, (int)green_slider.Value, (int)blue_slider.Value);
            preview_label.Text = $"Preview ( {(int)red_slider.Value}, {(int)green_slider.Value}, {(int)blue_slider.Value} ) :";
        }

        private void red_slider_Scroll(object sender, ScrollEventArgs e)
        {
            previewpanel.BackColor = System.Drawing.Color.FromArgb((int)red_slider.Value, (int)green_slider.Value, (int)blue_slider.Value);
            preview_label.Text = $"Preview ( {(int)red_slider.Value}, {(int)green_slider.Value}, {(int)blue_slider.Value} ) :";
        }

        private void blue_slider_Scroll(object sender, ScrollEventArgs e)
        {
            previewpanel.BackColor = System.Drawing.Color.FromArgb((int)red_slider.Value, (int)green_slider.Value, (int)blue_slider.Value);
            preview_label.Text = $"Preview ( {(int)red_slider.Value}, {(int)green_slider.Value}, {(int)blue_slider.Value} ) :";
        }

        private void applyui_Click(object sender, EventArgs e)
        {
            current_color = System.Drawing.Color.FromArgb((int)red_slider.Value, (int)green_slider.Value, (int)blue_slider.Value);
            Form[] forms = { P, C, H, D };
            foreach (Form form in forms)
            {
                foreach (Guna.UI2.WinForms.Guna2Panel panel in form.Controls)
                {
                    foreach (Control obj in panel.Controls)
                    {
                        if (obj.GetType() == typeof(Guna.UI2.WinForms.Guna2Button))
                        {
                            Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)obj;
                            button.HoverState.BorderColor = current_color;
                            button.HoverState.CustomBorderColor = current_color;
                            button.CheckedState.ForeColor = current_color;
                            button.CheckedState.BorderColor = current_color;
                            button.CheckedState.CustomBorderColor = current_color;
                        }
                        if (obj.GetType() == typeof(Guna.UI2.WinForms.Guna2CheckBox))
                        {
                            Guna.UI2.WinForms.Guna2CheckBox checkbox = (Guna.UI2.WinForms.Guna2CheckBox)obj;
                            checkbox.CheckedState.FillColor = current_color;
                            checkbox.CheckedState.BorderColor = current_color;
                        }
                        if (obj.GetType() == typeof(ColorSlider.ColorSlider))
                        {
                            ColorSlider.ColorSlider slider = (ColorSlider.ColorSlider)obj;
                            slider.ElapsedInnerColor = Calls.current_color;
                            slider.ElapsedPenColorBottom = Calls.current_color;
                            slider.ElapsedPenColorTop = Calls.current_color;
                            slider.ThumbInnerColor = Calls.current_color;
                            slider.ThumbOuterColor = Calls.current_color;
                            slider.ThumbPenColor = Calls.current_color;
                        }

                        if (obj.GetType() == typeof(Guna.UI2.WinForms.Guna2Panel))
                        {
                            foreach (object obj_child in ((Guna.UI2.WinForms.Guna2Panel)obj).Controls)
                            {
                                if (obj_child.GetType() == typeof(Guna.UI2.WinForms.Guna2Button))
                                {
                                    Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)obj_child;
                                    button.HoverState.BorderColor = current_color;
                                    button.HoverState.CustomBorderColor = current_color;
                                    button.CheckedState.ForeColor = current_color;
                                    button.CheckedState.BorderColor = current_color;
                                    button.CheckedState.CustomBorderColor = current_color;
                                }
                                if (obj_child.GetType() == typeof(Guna.UI2.WinForms.Guna2CheckBox))
                                {
                                    Guna.UI2.WinForms.Guna2CheckBox checkbox = (Guna.UI2.WinForms.Guna2CheckBox)obj_child;
                                    checkbox.CheckedState.FillColor = current_color;
                                    checkbox.CheckedState.BorderColor = current_color;
                                }
                                if (obj_child.GetType() == typeof(ColorSlider.ColorSlider))
                                {
                                    ColorSlider.ColorSlider slider = (ColorSlider.ColorSlider)obj_child;
                                    slider.ElapsedInnerColor = Calls.current_color;
                                    slider.ElapsedPenColorBottom = Calls.current_color;
                                    slider.ElapsedPenColorTop = Calls.current_color;
                                    slider.ThumbInnerColor = Calls.current_color;
                                    slider.ThumbOuterColor = Calls.current_color;
                                    slider.ThumbPenColor = Calls.current_color;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Config Control
        private void LoadConfingBtn_Click(object sender, EventArgs e)
        {
            UrlDialog dialog = new UrlDialog();
            dialog.ShowDialog(this);
            try
            {
                string dwn_config = new WebClient().DownloadString(dialog.ConfigURL);
                Config _config = JsonConvert.DeserializeObject<Config>(dwn_config);
                boostmaxslider.Value = _config.BoostMax;
                dropmaxslider.Value = _config.DropMax;
                dropminslider.Value = _config.DropMin;
                boostminslider.Value = _config.BoostMin;
                chanceboostslider.Value = _config.ChanceBoost;
                randomseedslider.Value = _config.RandomSeed;
            }
            catch (Exception ex)
            { 
                if (ex.GetType() == typeof(WebException))
                {
                    MessageBox.Show("Download Error", "Config Loader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Bad Input", "Config Loader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void Catmode_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Form[] forms = { P, C, H, D };
            foreach (Form form in forms)
            {
                form.BackgroundImage = Properties.Resources.Cat;
                foreach (Guna.UI2.WinForms.Guna2Panel panel in form.Controls)
                {
                    panel.BackColor = System.Drawing.Color.Transparent;
                    panel.FillColor = System.Drawing.Color.Transparent;
                    foreach (Control obj in panel.Controls)
                    {
                        if (obj.GetType() == typeof(Guna.UI2.WinForms.Guna2Button))
                        {
                            Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)obj;
                            button.BackColor = System.Drawing.Color.Transparent;
                            button.FillColor = System.Drawing.Color.Transparent;
                            button.HoverState.FillColor = System.Drawing.Color.Transparent;
                            button.CheckedState.FillColor = System.Drawing.Color.Transparent;
                        }
                        if (obj.GetType() == typeof(Guna.UI2.WinForms.Guna2Panel))
                        {
                            Guna.UI2.WinForms.Guna2Panel panel_ = (Guna.UI2.WinForms.Guna2Panel)obj;
                            panel_.BackColor = System.Drawing.Color.Transparent;
                            panel_.FillColor = System.Drawing.Color.Transparent;
                            foreach (object obj_child in panel_.Controls)
                            {
                                if (obj_child.GetType() == typeof(Guna.UI2.WinForms.Guna2Button))
                                {
                                    Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)obj_child;
                                    button.FillColor = System.Drawing.Color.Transparent;
                                    button.BackColor = System.Drawing.Color.Transparent;
                                    button.HoverState.FillColor = System.Drawing.Color.Transparent;
                                    button.CheckedState.FillColor = System.Drawing.Color.Transparent;
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void UpldCfgBtn_Click(object sender, EventArgs e)
        {
            ConfigDialog cfgdialg = new ConfigDialog();
            cfgdialg.ShowDialog(this);
            try
            {
                HttpClient client = new HttpClient();
                Config cfg = new Config(BoostMax, DropMax, BoostMin, DropMin, ChanceBoost, RandomSeed);
                StringContent str = new StringContent($"{JsonConvert.SerializeObject(cfg)}", Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"https://CrimsonGraveMonad.pickleft.repl.co/Settings?CfgName={cfgdialg.ConfigName}&USER_ID={cfgdialg.ID}", str); // swift manager website
                if (result.Content.ReadAsStringAsync().Result.Contains("Success -> "))
                {
                    MessageBox.Show("Confirmation Sent");
                }
                else
                {
                    MessageBox.Show("Failed To Upload => " + result.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
