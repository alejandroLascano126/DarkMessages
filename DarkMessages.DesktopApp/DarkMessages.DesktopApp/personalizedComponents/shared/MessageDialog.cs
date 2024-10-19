using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkMessages.DesktopApp.personalizedComponents.shared
{
    public partial class MessageDialog : Form
    {
        private string _predicateText { get; set; }
        public string predicateText
        {
            get
            {
                return _predicateText;
            }
            set
            {
                _predicateText = value;
                txtPredicateMessage.Text = _predicateText;
            }
        }
        public MessageDialog()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
