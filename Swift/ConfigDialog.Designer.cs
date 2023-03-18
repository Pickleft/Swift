namespace Swift
{
    partial class ConfigDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CFGNAMETEXTBOX = new Guna.UI2.WinForms.Guna2TextBox();
            this.IDTEXTBOX = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // CFGNAMETEXTBOX
            // 
            this.CFGNAMETEXTBOX.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.CFGNAMETEXTBOX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CFGNAMETEXTBOX.DefaultText = "";
            this.CFGNAMETEXTBOX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CFGNAMETEXTBOX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CFGNAMETEXTBOX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CFGNAMETEXTBOX.DisabledState.Parent = this.CFGNAMETEXTBOX;
            this.CFGNAMETEXTBOX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CFGNAMETEXTBOX.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.CFGNAMETEXTBOX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CFGNAMETEXTBOX.FocusedState.Parent = this.CFGNAMETEXTBOX;
            this.CFGNAMETEXTBOX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CFGNAMETEXTBOX.HoverState.Parent = this.CFGNAMETEXTBOX;
            this.CFGNAMETEXTBOX.Location = new System.Drawing.Point(12, 55);
            this.CFGNAMETEXTBOX.Name = "CFGNAMETEXTBOX";
            this.CFGNAMETEXTBOX.PasswordChar = '\0';
            this.CFGNAMETEXTBOX.PlaceholderText = "Config Name";
            this.CFGNAMETEXTBOX.SelectedText = "";
            this.CFGNAMETEXTBOX.ShadowDecoration.Parent = this.CFGNAMETEXTBOX;
            this.CFGNAMETEXTBOX.Size = new System.Drawing.Size(410, 37);
            this.CFGNAMETEXTBOX.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.CFGNAMETEXTBOX.TabIndex = 1;
            this.CFGNAMETEXTBOX.TextChanged += new System.EventHandler(this.CFGNAMETEXTBOX_TextChanged);
            // 
            // IDTEXTBOX
            // 
            this.IDTEXTBOX.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.IDTEXTBOX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDTEXTBOX.DefaultText = "";
            this.IDTEXTBOX.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.IDTEXTBOX.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.IDTEXTBOX.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDTEXTBOX.DisabledState.Parent = this.IDTEXTBOX;
            this.IDTEXTBOX.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDTEXTBOX.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.IDTEXTBOX.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDTEXTBOX.FocusedState.Parent = this.IDTEXTBOX;
            this.IDTEXTBOX.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDTEXTBOX.HoverState.Parent = this.IDTEXTBOX;
            this.IDTEXTBOX.Location = new System.Drawing.Point(12, 12);
            this.IDTEXTBOX.Name = "IDTEXTBOX";
            this.IDTEXTBOX.PasswordChar = '\0';
            this.IDTEXTBOX.PlaceholderText = "Discord ID";
            this.IDTEXTBOX.SelectedText = "";
            this.IDTEXTBOX.ShadowDecoration.Parent = this.IDTEXTBOX;
            this.IDTEXTBOX.Size = new System.Drawing.Size(410, 37);
            this.IDTEXTBOX.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.IDTEXTBOX.TabIndex = 2;
            this.IDTEXTBOX.TextChanged += new System.EventHandler(this.IDTEXTBOX_TextChanged);
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(431, 100);
            this.Controls.Add(this.IDTEXTBOX);
            this.Controls.Add(this.CFGNAMETEXTBOX);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigDialog";
            this.ShowIcon = false;
            this.Text = "Config Uploader";
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox CFGNAMETEXTBOX;
        private Guna.UI2.WinForms.Guna2TextBox IDTEXTBOX;
    }
}