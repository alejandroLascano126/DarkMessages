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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarkMessages.DesktopApp
{
    public partial class MainPage : Form
    {
        public Container container { get; set; }
        HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        public async Task loadUserItems()
        {
            try
            {
                string urlPost = "api/darkmsgs/consultFriends";
                rqConsultFriends rqInsertMessage = new rqConsultFriends() { username = container.username, rows = 10, page = 1, option = "" };
                var rqSerialized = JsonSerializer.Serialize(rqInsertMessage);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultFriends rp = JsonSerializer.Deserialize<rpConsultFriends>(responseBody) ?? new rpConsultFriends();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    foreach (var friend in rp.friends) 
                    {
                        UserItem item = new UserItem();
                        item.name = friend.name;
                        item.description = friend.lastChatMessage;
                        item.username = container.username;
                        item.usernameFriend = friend.username;
                        item.container = this;
                        flpItemsUser.Controls.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private async void MainPage_Load(object sender, EventArgs e)
        {
            await loadUserItems();
            ChatFormInitializer(null, null, null);
        }

        public void ChatFormInitializer(string? name, string? username, string? receiver) 
        {
            if (panelChat.Controls.Count > 0) 
            {
                panelChat.Controls.Clear(); 
            }
            ChatForm chatForm = new ChatForm();
            chatForm.name = name ?? "";
            chatForm.userName = username ?? "";
            chatForm.receiver = receiver ?? "";
            chatForm.container = this;
            chatForm.TopLevel = false;
            chatForm.Dock = DockStyle.Fill;
            panelChat.Controls.Add(chatForm);
            panelChat.Tag = chatForm;
            chatForm.Size = panelChat.Size;
            chatForm.Show();
        }
    }
}
