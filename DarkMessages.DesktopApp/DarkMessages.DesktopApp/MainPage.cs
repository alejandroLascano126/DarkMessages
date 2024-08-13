using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
using DarkMessages.models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarkMessages.DesktopApp
{
    public partial class MainPage : Form
    {
        public Container container { get; set; }
        public User user { get; set; }
        HttpClient client = new HttpClient();
        UsersQueryView usersQueryView = new UsersQueryView();
        private string buttonSelectedBefore;
        public MainPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        private async void MainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = container.user.name + " " + container.user.lastname;
            ChatFormInitializer(null, null, true, false, null, null);
            colorSelectedButton("Chats");
            flpItemsUserInitializer();
        }

        public void ChatFormInitializer(string? username, chat? chat, bool isFriend, bool isFriendRequest, Notification? notification, bool? isRequestSent)
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            ChatFormPrivate chatForm = new ChatFormPrivate();
            chatForm.userName = username ?? "";
            chatForm.chat = chat ?? new chat();
            chatForm.isFriend = isFriend;
            chatForm.isFriendRequest = isFriendRequest;
            chatForm.notification = notification ?? new Notification();
            chatForm.isRequestSent = isRequestSent ?? false;
            chatForm.container = this;
            chatForm.TopLevel = false;
            chatForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(chatForm);
            chatForm.Tag = chatForm;
            chatForm.Size = panelChat.Size;
            chatForm.Show();
        }

        public void flpItemsUserInitializer()
        {
            if (panelUsers.Controls.Count > 0)
            {
                panelUsers.Controls.Clear();
            }
            ChatList friendsList = new ChatList();
            friendsList.mainPage = this;
            friendsList.container = container;
            friendsList.TopLevel = false;
            friendsList.Dock = DockStyle.Fill;
            panelUsers.Controls.Add(friendsList);
            friendsList.Tag = friendsList;
            friendsList.Size = panelUsers.Size;
            friendsList.Show();
        }

        private void txtSearchFriends_Click(object sender, EventArgs e)
        {
            flpQueryUserInitializer();
            usersQueryView.value = txtSearchFriends.Text;
        }

        public void flpQueryUserInitializer()
        {
            if (panelUsers.Controls.Count > 0)
            {
                panelUsers.Controls.Clear();
            }
            usersQueryView.mainPage = this;
            usersQueryView.container = container;
            usersQueryView.TopLevel = false;
            usersQueryView.value = "";
            panelUsers.Controls.Add(usersQueryView);
            usersQueryView.Tag = usersQueryView;
            usersQueryView.Size = panelUsers.Size;
            usersQueryView.Show();
        }

        private void txtSearchFriends_TextChanged(object sender, EventArgs e)
        {
            usersQueryView.value = txtSearchFriends.Text;
        }



        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            colorSelectedButton("New Group");
            CreateGroupFormInitializer();
        }

        public void CreateGroupFormInitializer()
        {
            if (panelUsers.Controls.Count > 0)
            {
                panelUsers.Controls.Clear();
            }
            CreateGroupForm createGroupForm = new CreateGroupForm();
            createGroupForm.TopLevel = false;
            createGroupForm.user = user;
            panelUsers.Controls.Add(createGroupForm);
            createGroupForm.Tag = createGroupForm;
            createGroupForm.Size = panelUsers.Size;
            createGroupForm.Show();

        }

        public void ChatFormGroupInitializer(string username, chat chat)
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            ChatFormGroup chatForm = new ChatFormGroup();
            chatForm.userName = username ?? "";
            chatForm.chat = chat;
            chatForm.container = this;
            chatForm.TopLevel = false;
            chatForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(chatForm);
            panelChat.Tag = chatForm;
            chatForm.Size = panelChat.Size;
            chatForm.Show();
        }

        public void GroupSettingsFormInitializer(chat chat)
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            GroupSettingsForm groupSettingsForm = new GroupSettingsForm();
            groupSettingsForm.chat = chat;
            groupSettingsForm.container = container;
            groupSettingsForm.mainPage = this;
            groupSettingsForm.TopLevel = false;
            groupSettingsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(groupSettingsForm);
            groupSettingsForm.Tag = groupSettingsForm;
            groupSettingsForm.Size = panelChat.Size;
            groupSettingsForm.Show();
        }


        public void NotificationsListInitializer()
        {
            if (panelUsers.Controls.Count > 0)
            {
                panelUsers.Controls.Clear();
            }
            NotificationsList notificationsList = new NotificationsList();
            notificationsList.container = container;
            notificationsList.mainPage = this;
            notificationsList.TopLevel = false;
            notificationsList.Dock = DockStyle.Fill;
            panelUsers.Controls.Add(notificationsList);
            notificationsList.Tag = notificationsList;
            notificationsList.Size = panelUsers.Size;
            notificationsList.Show();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            colorSelectedButton("News");
            NotificationsListInitializer();
        }

        public void SettingsFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.container = container;
            settingsForm.user = user;
            settingsForm.mainPage = this;
            settingsForm.TopLevel = false;
            settingsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(settingsForm);
            settingsForm.Tag = settingsForm;
            settingsForm.Size = panelChat.Size;
            settingsForm.Show();
        }

        private void btnChats_Click(object sender, EventArgs e)
        {
            colorSelectedButton("Chats");
            flpItemsUserInitializer();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            colorSelectedButton("Contacts");
            flpQueryUserInitializer();
            usersQueryView.value = txtSearchFriends.Text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelChat.Controls.ContainsKey("SettingsForm"))
            {
                panelChat.Controls.Clear();
                ChatFormInitializer(null, null, true, false, null, null);
            }
            else 
            {
                SettingsFormInitializer();
            }
            
        }

        private void colorSelectedButton(string buttonName) 
        {
            if (!string.IsNullOrEmpty(buttonSelectedBefore) && buttonName != buttonSelectedBefore) 
            {
                DeselectButton(buttonSelectedBefore);
            }
            buttonSelectedBefore = buttonName;
            switch (buttonName) 
            {
                case "Chats":
                    btnChats.BackColor = SystemColors.Highlight;
                    break;
                case "Contacts":
                    btnContacts.BackColor = SystemColors.Highlight;
                    break;
                case "News":
                    btnNotifications.BackColor = SystemColors.Highlight;
                    break;
                case "New Group":
                    btnCreateGroup.BackColor = SystemColors.Highlight;
                    break;

            }
        }


        private void DeselectButton(string buttonName) 
        {
            switch (buttonName)
            {
                case "Chats":
                    btnChats.BackColor = Color.DodgerBlue;
                    break;
                case "Contacts":
                    btnContacts.BackColor = Color.DodgerBlue;
                    break;
                case "News":
                    btnNotifications.BackColor = Color.DodgerBlue;
                    break;
                case "New Group":
                    btnCreateGroup.BackColor = Color.DodgerBlue;
                    break;

            }
        }
    }
}
