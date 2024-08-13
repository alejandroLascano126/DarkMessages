using DarkMessages.models.Chats;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
using DarkMessages.models.Usuarios;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DarkMessages.DesktopApp
{
    public partial class NotificationsList : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        private HubConnection hubConnection;
        private int notificationsCount {get;set;}
        private int rows = 5;
        private int page = 1;
        private int maxPage = 0;
        private int minPage = 1;
        public NotificationsList()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            InitializeSignalR();
        }

        private async void NotificationsList_Load(object sender, EventArgs e)
        {
            notificationsCount = await countNotifications();
            maxPage = (int)Math.Ceiling((double)notificationsCount / rows);

            await loadNotifications(rows,page);
        }

        public async Task loadNotifications(int rows, int page)
        {
            try
            {
                string urlPost = "api/darkmsgs/mantNotifications";
                rqMantNotifications rqMantNotifications = new rqMantNotifications() { username = container.user.userName, rows = rows, page = page, notificationId = 0, option = "CON" };
                var rqSerialized = JsonSerializer.Serialize(rqMantNotifications);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpMantNotifications rp = JsonSerializer.Deserialize<rpMantNotifications>(responseBody) ?? new rpMantNotifications();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    if (rp.notifications != null)
                    {
                        if (rp.notifications.Count > 0)
                        {
                            if (flpNotifications.Controls.Count > 0)
                            {
                                flpNotifications.Controls.Clear();
                            }
                            foreach (var notification in rp.notifications)
                            {
                                string username = "";
                                string name = "";
                                string email = "";
                                string groupName = "";
                                string groupId = "";
                                string userIdRelated = "";
                                string description =  "";
                                JObject infoData = JObject.Parse(notification.infoJson);

                                chat chat = new chat();

                                NotificatioItm notificatioItm = new NotificatioItm();
                                notificatioItm.name = notification.title;
                                notificatioItm.description = notification.description;
                                notificatioItm.notification = notification;
                                notificatioItm.mainPage = mainPage;
                                notificatioItm.container = container;

                                switch (notification.typeId) 
                                {
                                     case 1 :
                                     case 2 :
                                        if (infoData != null && infoData.ContainsKey("usernameFirst"))
                                        {
                                            username = infoData["usernameFirst"]!.ToString();
                                            name = infoData["completeName"]!.ToString();
                                            email = infoData["email"]!.ToString();
                                            chat = new chat() { name = name, friendUsername = username, email = email };
                                        }
                                        break;
                                     case 3 :
                                        break;
                                     case 4 :
                                        if (infoData != null && infoData.ContainsKey("description"))
                                        {
                                            groupName = infoData["groupName"]!.ToString();
                                            groupId = infoData["groupId"]!.ToString();
                                            userIdRelated = infoData["userIdRelated"]!.ToString();
                                            description = infoData["description"]!.ToString();
                                            chat = new chat() { name = groupName, entityId = Convert.ToInt32(groupId), userIdRelated = Convert.ToInt32(userIdRelated), description = description };
                                        }
                                        break;
                                     case 5 :
                                        if (infoData != null && infoData.ContainsKey("usernameFirst"))
                                        {
                                            username = infoData["usernameFirst"]!.ToString();
                                            name = infoData["completeName"]!.ToString();
                                            email = infoData["email"]!.ToString();
                                            chat = new chat() { name = name, friendUsername = username, email = email };
                                        }
                                        break;
                                }

                                
                                notificatioItm.chat = chat;
                                notificatioItm.NotificationsList = this;
                                flpNotifications.Controls.Add(notificatioItm);
                            }
                        }
                    }
                    else
                    {
                        rp.notifications = new List<Notification>();
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

        private async void loadNew() 
        {
            await loadNotifications(rows, 1);
        } 


        private async void InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{GlobalVariables.url}chathub").Build();

            hubConnection.On<rpConsultMessages>("ReceiveNotifications", (incominggMessage) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => loadNew()));
                }
                else
                {
                    loadNew();
                }
            });
            await hubConnection.StartAsync();
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;


        public async Task<int> countNotifications()
        {
            try
            {
                string urlPost = "api/darkmsgs/mantNotifications";
                rqMantNotifications rqMantNotifications = new rqMantNotifications() { username = container.user.userName, rows = 0, page = 0, notificationId = 0, option = "COUNT" };
                var rqSerialized = JsonSerializer.Serialize(rqMantNotifications);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpMantNotifications rp = JsonSerializer.Deserialize<rpMantNotifications>(responseBody) ?? new rpMantNotifications();
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

        private async void FlpNotifications_MouseWheel(object sender, MouseEventArgs e)
        {
            notificationsCount = await countNotifications();
            if (notificationsCount > rows)
            {
                if (e.Delta > 0) //up
                {
                    if (pageScrollHelp(--page))
                        await loadNotifications(rows, page);
                }
                else //down
                {
                    if (pageScrollHelp(++page))
                        await loadNotifications(rows, page);
                }
            }
        }
    }
}
