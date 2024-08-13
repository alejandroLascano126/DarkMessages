using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
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
        HttpClient client = new HttpClient();

        public UserItem()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
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

        private async void UserItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (groupSettingsForm == null)
            {
                if (isContact)
                {
                    bool isRequestSent = await consultfriendshipsRequests(container.user.userName, usernameFriend);
                    bool isAcceptRequestAvailable = await consultfriendshipsRequests(usernameFriend, container.user.userName);
                    container.ChatFormInitializer(username, chat, isFriend, isAcceptRequestAvailable, null, isRequestSent, null);
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

        private async Task<bool> consultfriendshipsRequests(string usernameSender, string usernameReceiver)
        {
            try
            {
                string urlPost = "api/darkmsgs/conusltfriendshipsRequests";
                
                rqConsultfriendshipsRequests rqConsultfriendshipsRequests = new rqConsultfriendshipsRequests() { usernameSender = usernameSender, usernameReceiver = usernameReceiver };
                var rqSerialized = JsonSerializer.Serialize(rqConsultfriendshipsRequests);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultChats rp = JsonSerializer.Deserialize<rpConsultChats>(responseBody) ?? new rpConsultChats();
                if (rp.success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }

            return false;
        }
    }
}
