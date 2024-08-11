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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarkMessages.DesktopApp
{
    public partial class ChatList : Form
    {
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        HttpClient client = new HttpClient();
        private int page = 1;
        private int chatsCount;
        int rows = 5;

        public ChatList()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            
        }

        private async void FriendsList_Load(object sender, EventArgs e)
        {
            flpItemsUser.Size = Size;

            chatsCount = await countChats();
            //page = (int)Math.Ceiling((double)chatsCount / rows);
            //page = (page == 0) ? 1 : page;

            await loadUserItems(rows, page);
        }

        public async Task loadUserItems(int _rows, int _page)
        {
            try
            {
                string urlPost = "api/darkmsgs/consultChats";
                rqConsultChats rqInsertMessage = new rqConsultChats() { username = container.user.userName, rows = _rows, page = _page };
                var rqSerialized = JsonSerializer.Serialize(rqInsertMessage);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultChats rp = JsonSerializer.Deserialize<rpConsultChats>(responseBody) ?? new rpConsultChats();
                if (rp.success)
                {
                    if (rp.chats.Count > 0) 
                    {
                        if (flpItemsUser.Controls.Count > 0)
                        {
                            flpItemsUser.Controls.Clear();
                        }
                        foreach (var chat in rp.chats)
                        {
                            UserItem item = new UserItem();
                            item.chat = chat;
                            item.name = chat.name ?? "";
                            item.description = chat.lastMessage ?? "";
                            item.username = container.user.userName;
                            item.usernameFriend = chat.friendUsername ?? "";
                            //1 contact  2 group
                            item.isFriend = (!string.IsNullOrEmpty(chat.friendUsername)) ? true : false;
                            item.isContact = chat.typeChatId == 1 ? true : false;
                            item.container = mainPage;
                            flpItemsUser.Controls.Add(item);
                        }
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

        public async Task<int> countChats()
        {
            try
            {
                string urlPost = "api/darkmsgs/countChats";
                rqCountChats rqCountChats = new rqCountChats() { username = container.user.userName };
                var rqSerialized = JsonSerializer.Serialize(rqCountChats);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpCountChats rp = JsonSerializer.Deserialize<rpCountChats>(responseBody) ?? new rpCountChats();
                if (rp.success)
                {
                    return rp.count;
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
            return 0;
        }

        private async void FlpItemsUser_MouseWheel(object sender, MouseEventArgs e)
        {
            chatsCount = await countChats();
            if (chatsCount > rows) 
            {
                if (e.Delta > 0) //up
                {
                    await loadUserItems(rows, --page);
                }
                else //down
                {
                    await loadUserItems(rows, ++page);
                }
            }
            
        }

    }
}
