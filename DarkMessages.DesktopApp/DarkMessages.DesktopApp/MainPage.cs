using DarkMessages.models.Friends;
using DarkMessages.models.Message;
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
        HttpClient client = new HttpClient();
        UsersQueryView usersQueryView = new UsersQueryView();
        public MainPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        private async void MainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = container.name + " " + container.lastname;
            ChatFormInitializer(null, null, null,true, null);
            flpItemsUserInitializer();
        }

        public void ChatFormInitializer(string? name, string? username, string? receiver, bool isFriend, string? email)
        {
            if (panelChat.Controls.Count > 0)
            {
                panelChat.Controls.Clear();
            }
            ChatForm chatForm = new ChatForm();
            chatForm.name = name ?? "";
            chatForm.userName = username ?? "";
            chatForm.receiver = receiver ?? "";
            chatForm.isFriend = isFriend;
            chatForm.email = email ?? "";
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
            FriendsList friendsList = new FriendsList();
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
            ChatFormInitializer(null, null, null, true, null);
        }
    }
}
