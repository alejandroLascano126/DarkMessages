using DarkMessages.models.Friends;
using DarkMessages.models.Chats;
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
    public partial class ChatList : Form
    {
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        HttpClient client = new HttpClient();   

        public ChatList()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            
        }

        private async void FriendsList_Load(object sender, EventArgs e)
        {
            flpItemsUser.Size = Size;
            await loadUserItems();
        }

        public async Task loadUserItems()
        {
            try
            {
                string urlPost = "api/darkmsgs/consultChats";
                rqConsultChats rqInsertMessage = new rqConsultChats() { username = container.user.userName, rows = 10, page = 1 };
                var rqSerialized = JsonSerializer.Serialize(rqInsertMessage);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultChats rp = JsonSerializer.Deserialize<rpConsultChats>(responseBody) ?? new rpConsultChats();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    foreach (var chat in rp.chats)
                    {
                        UserItem item = new UserItem();
                        item.name = chat.name;
                        item.description = chat.lastMessage ?? "";
                        item.username = container.user.userName;
                        item.usernameFriend = chat.friendUsername ?? "";
                        //1 contact  2 group
                        item.isContact = chat.typeChatId == 1 ? true : false;
                        item.email = chat.email ?? "";
                        item.container = mainPage;
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

        
    }
}
