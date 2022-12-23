using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swift
{
    public partial class UrlDialog : Form
    {
        public UrlDialog()
        {
            InitializeComponent();
        }

        public string ConfigURL { get; private set; }

        private void URLTextBox_TextChanged(object sender, EventArgs e)
        {
            ConfigURL = URLTextBox.Text;
        }

        private void UrlDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
