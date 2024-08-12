using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Usuarios;
using Newtonsoft.Json.Linq;
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
        private int page = 1;
        private int rows = 5;
        private int usersCount = 0;
        private int maxPage = 0;
        private int minPage = 1;

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
            usersCount = await countUserItems();
            maxPage = (int)Math.Ceiling((double)usersCount / rows);
            //page = usersCount / rows;
            //page = (page == 0) ? 1 : page;

            await loadUserItems(5, 1);
        }

        public async Task loadUserItems(int rows, int page)
        {
            try
            {
                string urlPost = "api/darkmsgs/filterUsers";
                rqUserQuery rqUserQuery = new rqUserQuery() { value = _value, username = container.user.userName, rows = rows, page = page, option = "FIL" };
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
                        if (rp.users.Count > 0) 
                        {
                            if (flpUsersQuery.Controls.Count > 0)
                            {
                                flpUsersQuery.Controls.Clear();
                            }
                            foreach (var user in rp.users)
                            {
                                chat chat = new chat() { name = user.name ?? "", friendUsername = user.userName ?? "", email = user.email };
                                UserItem item = new UserItem();
                                item.name = $"{user.name} {user.lastname}" ?? "";
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


        public async Task<int> countUserItems()
        {
            try
            {
                string urlPost = "api/darkmsgs/filterUsers";
                rqUserQuery rqUserQuery = new rqUserQuery() { value = _value, username = container.user.userName, rows = 0, page = 0, option = "COUNT" };
                var rqSerialized = JsonSerializer.Serialize(rqUserQuery);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpUserQuery rp = JsonSerializer.Deserialize<rpUserQuery>(responseBody) ?? new rpUserQuery();
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

        private async void FlpUsersQuery_MouseWheel(object sender, MouseEventArgs e)
        {
            usersCount = await countUserItems();
            if (usersCount > rows) 
            {
                if (e.Delta > 0) //up
                {
                    if(pageScrollHelp(--page))
                        await loadUserItems(rows, page);
                }
                else //down
                {
                    if(pageScrollHelp(++page))
                        await loadUserItems(rows, page);
                }
            }
        }

        private bool pageScrollHelp(int value) 
        {
            if (value < minPage) 
            {                
                page = 1;
                return false;
            }
            if (value > maxPage) 
            {
                page--;
                return false;
            }
            return true;
        }
    }
}
