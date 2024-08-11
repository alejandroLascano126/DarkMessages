using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
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

namespace DarkMessages.DesktopApp
{
    public partial class UsersQueryView : Form
    {
        private string _value;
        HttpClient client = new HttpClient();
        public MainPage mainPage { get; set; }
        public Container container { get; set; }

        public string value
        {
            get { return value; }
            set { _value = value; loadUsersAsync(); }

        }
        
        public UsersQueryView()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);

        }

        public async void loadUsersAsync() 
        {
            await loadUserItems();
        }

        public async Task loadUserItems()
        {
            try
            {
                string urlPost = "api/darkmsgs/filterUsers";
                rqUserQuery rqUserQuery = new rqUserQuery() { value = _value, username = container.user.userName};
                var rqSerialized = JsonSerializer.Serialize(rqUserQuery);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpUserQuery rp = JsonSerializer.Deserialize<rpUserQuery>(responseBody) ?? new rpUserQuery();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    if (rp.users != null)
                    {
                        flpUsersQuery.Controls.Clear();
                        foreach (var user in rp.users)
                        {
                            chat chat = new chat() { name = user.name ?? "", friendUsername = user.userName ?? "", email = user.email };
                            UserItem item = new UserItem();
                            item.name = user.name ?? "";
                            item.description = (user.isFriend) ? "Friend" : "";
                            item.username = container.user.userName;
                            item.chat = chat;
                            item.usernameFriend = user.userName ?? "";
                            item.isFriend = user.isFriend;
                            item.isContact = true;
                            item.container = mainPage;
                            flpUsersQuery.Controls.Add(item);
                        }
                    }
                    else 
                    {
                        rp.users = new List<User>();
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

        private void UsersQueryView_Load(object sender, EventArgs e)
        {
            flpUsersQuery.Size = Size;
        }
    }
}
