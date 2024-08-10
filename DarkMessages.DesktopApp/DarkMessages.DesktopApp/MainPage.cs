using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Message;
using DarkMessages.models.Usuarios;
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
        public MainPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        private async void MainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = container.user.name + " " + container.user.lastname;
            ChatFormInitializer(null, null, true);
            flpItemsUserInitializer();
        }

        public void ChatFormInitializer(string? username, chat? chat, bool isFriend)
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            ChatFormPrivate chatForm = new ChatFormPrivate();
            chatForm.userName = username ?? "";
            chatForm.chat = chat ?? new chat();
            chatForm.isFriend = isFriend;
            chatForm.container = this;
            chatForm.TopLevel = false;
            chatForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(chatForm);
            panelChat.Tag = chatForm;
            chatForm.Size = panelChat.Size;
            chatForm.Show();
        }

        public void flpItemsUserInitializer()
        {
            btnBackFriends.Enabled = false;
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
            panelUsers.Tag = friendsList;
            friendsList.Size = panelUsers.Size;
            friendsList.Show();
        }

        private void txtSearchFriends_Click(object sender, EventArgs e)
        {
            flpQueryUserInitializer();
        }

        public void flpQueryUserInitializer()
        {
            btnBackFriends.Enabled = true;
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

        private void btnAtrasFriends_Click(object sender, EventArgs e)
        {
            flpItemsUserInitializer();
            ChatFormInitializer(null, null, true);
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            CreateGroupFormInitializer();
        }

        public void CreateGroupFormInitializer()
        {
            btnBackFriends.Enabled = true;
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

        public void GropSettingsFormInitializer()
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            GroupSettingsForm groupSettingsForm = new GroupSettingsForm();
            groupSettingsForm.TopLevel = false;
            groupSettingsForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(groupSettingsForm);
            panelChat.Tag = groupSettingsForm;
            groupSettingsForm.Size = panelChat.Size;
            groupSettingsForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Close();
            container.SettingsFormInitializer();
        }
    }
}
