using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaformItem
{
    public partial class itemPrueba : UserControl
    {
        public itemPrueba()
        {
            InitializeComponent();
        }

        private Image _icon;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image icon
        {
            get { return icon; }
            set { _icon = value; }
        }
    }
}
