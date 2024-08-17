using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
using DarkMessages.models.Usuarios;
using Microsoft.AspNetCore.Connections.Features;
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
        SettingsList settingsList = new SettingsList();
        private string buttonSelectedBefore;
        private string buttonSelected = "Chats";
        private TabType tabSelected { get; set; }
        public MainPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        private async void MainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = container.user.name + " " + container.user.lastname;
            ChatFormInitializer(null, null, true, false, null, null, null);
            colorSelectedButton("Chats");
            flpItemsUserInitializer();
        }

        public void ChatFormInitializer(string? username, chat? chat, bool isFriend, bool isFriendRequest, Notification? notification, bool? isRequestSent, NotificationsList? notificationsList)
        {
            if (chat != null)
                resetStateCache();
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
            chatForm.notificationsList = notificationsList ?? new NotificationsList();
            chatForm.TopLevel = false;
            chatForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(chatForm);
            chatForm.Tag = chatForm;
            chatForm.Size = panelChat.Size;
            chatForm.Show();
        }

        public void flpItemsUserInitializer()
        {
            tabSelected = TabType.chats;
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
            //flpQueryUserInitializer();
            //usersQueryView.value = txtSearchFriends.Text;
        }

        public void flpQueryUserInitializer()
        {
            tabSelected = TabType.contacts;
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
            if(usersQueryView.mainPage != null)
                usersQueryView.value = txtSearchFriends.Text;
            if(settingsList.mainPage != null)
                settingsList.value = txtSearchFriends.Text;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            buttonSelected = "New Group";
            colorSelectedButton("New Group");
            CreateGroupFormInitializer();
        }

        public void CreateGroupFormInitializer()
        {
            tabSelected = TabType.group;
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
            if (!string.IsNullOrEmpty(username) && chat != null)
                resetStateCache();

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
            tabSelected = TabType.news;
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
            buttonSelected = "News";
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
            buttonSelected = "Chats";
            colorSelectedButton("Chats");
            flpItemsUserInitializer();
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            buttonSelected = "Contacts";
            colorSelectedButton("Contacts");
            flpQueryUserInitializer();
            usersQueryView.value = txtSearchFriends.Text;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (panelUsers.Controls.ContainsKey("SettingsList"))
            {
                panelChat.Controls.Clear();
                if (GlobalVariables.chatType == ChatType.privateChat)
                    ChatFormInitializer(null, null, true, false, null, null, null);
                if (GlobalVariables.chatType == ChatType.groupChat)
                    ChatFormGroupInitializer(null, null);
                else
                    ChatFormInitializer(null, null, true, false, null, null, null);

                selectedTab(tabSelected);
            }
            else
            {
                DeselectButton(buttonSelected);
                SettingsListInitializer();
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

        private void resetStateCache()
        {
            GlobalVariables.chat = null;
            GlobalVariables.isFriend = null;
            GlobalVariables.notification = null;
            GlobalVariables.notificationsList = null;
            GlobalVariables.username = null;
            GlobalVariables.isFriendRequest = null;
            GlobalVariables.isRequestSent = null;
            GlobalVariables.chatType = null;
        }

        public void SettingsListInitializer()
        {
            if (panelUsers.Controls.Count > 0)
            {
                panelUsers.Controls.Clear();
            }
            settingsList = new SettingsList();
            settingsList.container = container;
            settingsList.mainPage = this;
            settingsList.TopLevel = false;
            panelUsers.Controls.Add(settingsList);
            settingsList.Tag = settingsList;
            settingsList.Size = panelUsers.Size;
            settingsList.Show();
        }

        private void selectedTab(TabType tabType) 
        {
            switch (tabType) 
            {
                case TabType.chats:
                    colorSelectedButton("Chats");
                    flpItemsUserInitializer();
                    break;
                case TabType.contacts:
                    colorSelectedButton("Contacts");
                    flpQueryUserInitializer();
                    break;
                case TabType.news:
                    colorSelectedButton("News");
                    NotificationsListInitializer();
                    break;
                case TabType.group:
                    colorSelectedButton("New Group");
                    CreateGroupFormInitializer();
                    break;
                default:
                    break;
            }
        }

        public void ProfileInformationFormInitializer() 
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            ProfileInformationForm profileInformationForm = new ProfileInformationForm();
            profileInformationForm.container = container;
            profileInformationForm.user = user;
            profileInformationForm.mainPage = this;
            profileInformationForm.TopLevel = false;
            profileInformationForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(profileInformationForm);
            profileInformationForm.Tag = profileInformationForm;
            profileInformationForm.Size = panelChat.Size;
            profileInformationForm.Show();
        }

        public void AccouuntInformationFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            AccountInformationForm accountInformationForm = new AccountInformationForm();
            accountInformationForm.container = container;
            accountInformationForm.user = user;
            accountInformationForm.mainPage = this;
            accountInformationForm.TopLevel = false;
            accountInformationForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(accountInformationForm);
            accountInformationForm.Tag = accountInformationForm;
            accountInformationForm.Size = panelChat.Size;
            accountInformationForm.Show();
        }

        public void PrivacyFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            PrivacyForm privacyForm = new PrivacyForm();
            privacyForm.container = container;
            privacyForm.user = user;
            privacyForm.mainPage = this;
            privacyForm.TopLevel = false;
            privacyForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(privacyForm);
            privacyForm.Tag = privacyForm;
            privacyForm.Size = panelChat.Size;
            privacyForm.Show();
        }

        public void FriendsFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            FriendsForm friendsForm = new FriendsForm();
            friendsForm.container = container;
            friendsForm.user = user;
            friendsForm.mainPage = this;
            friendsForm.TopLevel = false;
            friendsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(friendsForm);
            friendsForm.Tag = friendsForm;
            friendsForm.Size = panelChat.Size;
            friendsForm.Show();
        }

        public void GroupsFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            GroupsForm groupsForm = new GroupsForm();
            groupsForm.container = container;
            groupsForm.user = user;
            groupsForm.mainPage = this;
            groupsForm.TopLevel = false;
            groupsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(groupsForm);
            groupsForm.Tag = groupsForm;
            groupsForm.Size = panelChat.Size;
            groupsForm.Show();
        }

        public void SecurityCodeSettingsFormInitializer() 
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            SecurityCodeSettingsForm securityCodeSettingsForm = new SecurityCodeSettingsForm();
            securityCodeSettingsForm.container = container;
            securityCodeSettingsForm.user = user;
            securityCodeSettingsForm.mainPage = this;
            securityCodeSettingsForm.TopLevel = false;
            securityCodeSettingsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(securityCodeSettingsForm);
            securityCodeSettingsForm.Tag = securityCodeSettingsForm;
            securityCodeSettingsForm.Size = panelChat.Size;
            securityCodeSettingsForm.Show();
        }
    }
}
