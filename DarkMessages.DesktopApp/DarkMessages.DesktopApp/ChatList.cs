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
using DarkMessages.DesktopApp.Helpers;

namespace DarkMessages.DesktopApp
{
    public partial class ChatList : Form
    {
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        HttpClient client = new HttpClient();
        private int page = 1;
        private int chatsCount;
        private int rows = 5;
        private int maxPage = 0;
        private int minPage = 1;

        private int itemHeight = 76;
        private Size lastsize = new Size();

        public ChatList()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);

        }

        private async void FriendsList_Load(object sender, EventArgs e)
        {
            flpItemsUser.Size = Size;

            chatsCount = await countChats();
            maxPage = (int)Math.Ceiling((double)chatsCount / rows);

            //page = (int)Math.Ceiling((double)chatsCount / rows);
            //page = (page == 0) ? 1 : page;

            await loadUserItems(rows, page);
            lastsize = Size;
        }

        public async Task loadUserItems(int _rows, int _page)
        {
            try
            {
                string urlPost = "api/darkmsgs/consultChats";
                rqConsultChats rqInsertMessage = new rqConsultChats() { username = container.user.userName, rows = _rows, page = _page, option = "ALL", chatId = 0 };
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
                            if (chat.profilePicture != null)
                                item.icon = ImageHelper.ConvertBytesToImage(chat.profilePicture!);
                            else 
                            {
                                Bitmap groupBitmap = Properties.Resources.multiple_users_silhouette;
                                Bitmap privateBitmap = Properties.Resources.user_solid;
                                item.icon = (item.isContact) ? privateBitmap : groupBitmap;
                            }
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
                    if (pageScrollHelp(--page))
                        await loadUserItems(rows, page);
                }
                else //down
                {
                    if (pageScrollHelp(++page))
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

        private async void flpItemsUser_ClientSizeChanged(object sender, EventArgs e)
        {
            if ((Size.Height == 0 || Size.Height == 511 || Size.Height == 472) && lastsize.Height == 0)
                return;

            page = 1;
            rows = (Size.Height / itemHeight) - 1;
            chatsCount = await countChats();
            maxPage = (int)Math.Ceiling((double)chatsCount / rows);
            lastsize.Height = Size.Height;
            await loadUserItems(rows, page);
        }
    }
}
