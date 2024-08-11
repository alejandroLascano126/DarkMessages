using DarkMessages.models.Chats;
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
    public partial class UserItem : UserControl
    {

        private string _name;
        private string _description;
        private Image _icon;
        public MainPage container { get; set; }
        public bool isFriend { get; set; }
        public chat chat { get; set; }
        public string usernameFriend { get; set; }
        public string username { get; set; }
        public bool isContact { get; set; }
        public GroupSettingsForm? groupSettingsForm { get; set; }
        public bool groupMember { get; set; }

        public UserItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string name
        {
            get { return _name; }
            set { _name = value; lblname.Text = _name; }
        }


        [Category("Custom Props")]
        public string description
        {
            get { return _description; }
            set { _description = value; lblDescripcionItemUser.Text = _description; }

        }

        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image icon
        {
            get { return icon; }
            set { _icon = value; }
        }


        private void UserItem_MouseLeave(object sender, EventArgs e)    
        {
            this.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void UserItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void UserItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (groupSettingsForm == null)
            {
                if (isContact)
                {
                    container.ChatFormInitializer(username, chat, isFriend);
                }
                else
                {
                    container.ChatFormGroupInitializer(username, chat);
                }
            }
            else 
            {
                if (!groupMember) 
                {
                    groupSettingsForm.AsignData(chat);
                }
            }
        }
    }
}
