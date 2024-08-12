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
            mainPage.ChatFormInitializer(container.user.userName, chat, false, true, notification, null);
        }

        //private async Task<chat> consultChat()
        //{
        //    try
        //    {
        //        string urlPost = "api/darkmsgs/consultChats";
        //        rqConsultChats rqInsertMessage = new rqConsultChats() { username = container.user.userName, rows = 0, page = 0, option = "ONE", chatId = 0 };
        //        var rqSerialized = JsonSerializer.Serialize(rqInsertMessage);
        //        HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await client.PostAsync(urlPost, content);
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        rpConsultChats rp = JsonSerializer.Deserialize<rpConsultChats>(responseBody) ?? new rpConsultChats();
        //        if (rp.success)
        //        {
        //            if (rp.chats.Count > 0)
        //            {
        //                foreach (var chat in rp.chats)
        //                {
        //                    return chat;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex}");
        //    }

        //    return new chat();
        //}


    }
}
