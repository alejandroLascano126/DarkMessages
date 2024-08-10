using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkMessages.DesktopApp
{
    public partial class GroupMessageCell : UserControl
    {
        private string _nameUser;
        private string _title;
        private string _description;

        public string NameUser 
        {
            get { return _nameUser; }
            set { _nameUser = value; lblNameUser.Text = _nameUser; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; messageCell.Title = _title; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; messageCell.Description = _description; }
        }

        public GroupMessageCell()
        {
            InitializeComponent();
        }
    }
}
