using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkMessages.DesktopApp
{
    public partial class SettingItem : UserControl
    {

        private string _name;
        //private string _description;
        private Image _icon;
        public Container container { get; set; }
        public MainPage mainPage { get; set; }      
        public Control? panelChat { get; set; }
        HttpClient client = new HttpClient();

        public SettingItem()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        [Category("Custom Props")]
        public string name
        {
            get { return _name; }
            set { _name = value; lblNotificationTitle.Text = _name; }
        }


        //[Category("Custom Props")]
        //public string description
        //{
        //    get { return _description; }
        //    set { _description = value; lblDescripcionItemNotification.Text = _description; }

        //}

        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image icon
        {
            get { return icon; }
            set { _icon = value; picboxNotificationItem.Image = _icon; Invalidate(); }
        }


        private void UserItem_MouseLeave(object sender, EventArgs e)    
        {
            this.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void UserItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private async void UserItem_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_name) 
            {
                case "Profile Information":
                    mainPage.ProfileInformationFormInitializer();
                    break;
                case "Account Information":
                    mainPage.AccouuntInformationFormInitializer();
                    break;
                case "Privacy":
                    mainPage.PrivacyFormInitializer();
                    break ;
                case "Friends":
                    mainPage.FriendsFormInitializer();
                    break;
                case "Group":
                    mainPage.GroupsFormInitializer();
                    break;
                case "Settings":
                    mainPage.SettingsFormInitializer();
                    break;  
                default:
                    break;
            }
        } 
    }
}
