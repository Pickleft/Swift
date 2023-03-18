using System;
using System.Windows.Forms;

namespace Swift
{
    public partial class ConfigDialog : Form
    {
        #region Constructor .ctor
        public ConfigDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string ConfigURL { get; private set; }
        #endregion

        #region Methods
        private void IDTEXTBOX_TextChanged(object sender, EventArgs e)
        {
            if (ulong.TryParse(IDTEXTBOX.Text, out ulong id))
            {
                ID = id;
            }
            else
            {
                return;
            }
        }

        private void CFGNAMETEXTBOX_TextChanged(object sender, EventArgs e)
        {

            ConfigName = CFGNAMETEXTBOX.Text;
        }

        public ulong ID;
        public string ConfigName;
        #endregion
    }
}
