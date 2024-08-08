using DarkMessages.models.Friends;
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
    public partial class FriendsList : Form
    {
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        HttpClient client = new HttpClient();   

        public FriendsList()
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
                        item.isFriend = true;
                        item.email = friend.email;
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
