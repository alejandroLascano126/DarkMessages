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
    public partial class NotificatioItm : UserControl
    {

        private string _name;
        private string _description;
        private Image _icon;
        public Container container { get; set; }
        public Notification notification { get; set; }
        public MainPage mainPage { get; set; }
        public chat chat { get; set; }
        public NotificationsList NotificationsList { get; set; }
        HttpClient client = new HttpClient();

        public NotificatioItm()
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


        [Category("Custom Props")]
        public string description
        {
            get { return _description; }
            set { _description = value; lblDescripcionItemNotification.Text = _description; }

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

        private async void UserItem_MouseClick(object sender, MouseEventArgs e)
        {
            switch (notification.typeId) 
            {
                case 1:
                    mainPage.ChatFormInitializer(container.user.userName, chat, false, true, notification, null, NotificationsList);
                    break;
                case 2:
                    mainPage.ChatFormInitializer(container.user.userName, chat, true, false, notification, null, NotificationsList);
                    break;
                case 3:
                    mainPage.ChatFormInitializer(container.user.userName, chat, true, false, notification, null, NotificationsList);
                    break;
                case 4:
                    mainPage.ChatFormGroupInitializer(container.user.userName, chat);
                    break;
                case 5:
                    mainPage.ChatFormInitializer(container.user.userName, chat, true, false, notification, null, NotificationsList);
                    break;
                default: 
                    break;
            }
        }
    }
}
