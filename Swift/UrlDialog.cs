using System;
using System.Windows.Forms;

namespace Swift
{
    public partial class UrlDialog : Form
    {
        #region Constructor .ctor
        public UrlDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string ConfigURL { get; private set; }
        #endregion

        #region Methods
        private void URLTextBox_TextChanged(object sender, EventArgs e)
        {
            ConfigURL = URLTextBox.Text;
        }

        private void UrlDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        #endregion
    }
}
