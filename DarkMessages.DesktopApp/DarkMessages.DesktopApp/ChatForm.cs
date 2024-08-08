using DarkMessages.models.Friends;
using DarkMessages.models.Login;
using DarkMessages.models.Message;
using DarkMessages.models.SignUp;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;




namespace DarkMessages.DesktopApp
{
    public partial class ChatForm : Form
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string receiver { get; set; }
        public bool isFriend { get; set; }
        private List<DarkMessages.models.Message.message> messages { get; set; }
        public MainPage? container { get; set; }
        HttpClient client = new HttpClient();
        private int page;
        private int messagesCount;

        public ChatForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            InitializeSignalR();
            
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            lblNameChat.Text = name;

            messagesCount = await countMessages(userName, receiver);
            page = (int)Math.Ceiling((double)messagesCount / 7);
            page = (page == 0) ? 1 : page;
            messages = new List<DarkMessages.models.Message.message>() { };
            await consultMessages(userName, receiver, 7, page);

            if(userName == "" && receiver == "" && name == "") 
            {
                btnSendMessage.Enabled = false;
                rtbSendMessage.Enabled = false;
            }

            if (!isFriend) 
            {
                AddFriendButton();
            }
        }




        private async void btnSendMessage_Click(object sender, EventArgs e)
        {

            if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
            {
                await sendMessage(userName, receiver, rtbSendMessage.Text);
                
                rtbSendMessage.Text = "";
            }
        }

        private int currentRow = 0;
        private void AddMessage(string message, string time, bool isLeftAligned)
        {
            MessageCell messageCell = new MessageCell();
            messageCell.Title = message;
            messageCell.Description = time;

            if (isLeftAligned)
            {
                tlpMessagesChat.Controls.Add(messageCell, 0, currentRow);
            }
            else
            {
                tlpMessagesChat.Controls.Add(messageCell, 2, currentRow);
                messageCell.Anchor = AnchorStyles.Right;
            }
            currentRow++;
        }

        


        private async Task sendMessage(string sender, string receiver, string message)
        {
            try
            {
                string urlPost = "api/darkmsgs/insertMessage";
                rqInsertMessage rqInsertMessage = new rqInsertMessage() { senderUser = userName, receiverUser = receiver, messageContent = message };
                var rqSerialized = JsonSerializer.Serialize(rqInsertMessage);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpInsertMessage rp = JsonSerializer.Deserialize<rpInsertMessage>(responseBody) ?? new rpInsertMessage();
                if (rp.success)
                {
                    Console.WriteLine("Message sent correctly");
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


        private async Task consultMessages(string usernameSender, string usernameReceiver, int rows, int page)
        {
            try
            {
                string urlPost = "api/darkmsgs/consultMessages";
                rqConsultMessages rqConsultMessages = new rqConsultMessages() { usernameSender = usernameSender, usernameReceiver = usernameReceiver, rows = rows, page = page };
                var rqSerialized = JsonSerializer.Serialize(rqConsultMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultMessages rp = JsonSerializer.Deserialize<rpConsultMessages>(responseBody) ?? new rpConsultMessages();
                if (rp.success)
                {
                    if (rp.messages.Count > 0)
                    {
                        Console.WriteLine("Message consulted correctly");
                        DarkMessages.models.Message.message msg = new DarkMessages.models.Message.message();
                        msg = rp.messages.Last(); // last new message
                        if (rp.messages.Count - messages.Count == 1) // a new message received
                        {
                            AddMessage(msg.messageContent, msg.createdAt.ToString("HH:mm"), (msg.senderUser == userName) ? false : true);
                            insertLocalLastMessages(msg.messageContent);
                        }
                        else //many new messages
                        {
                            tlpMessagesChat.Controls.Clear();
                            foreach (var message in rp.messages)
                            {
                                AddMessage(message.messageContent, message.createdAt.ToString("HH:mm"), (message.senderUser == userName) ? false : true);
                            }
                            messages.Clear();
                        }

                        messages = rp.messages;
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

        private async Task<int> countMessages(string usernameSender, string usernameReceiver)
        {
            try
            {
                string urlPost = "api/darkmsgs/countMessages";
                rqCountMessages rqCountMessages = new rqCountMessages() { usernameSender = usernameSender, usernameReceiver = usernameReceiver };
                var rqSerialized = JsonSerializer.Serialize(rqCountMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpCountMessages rp = JsonSerializer.Deserialize<rpCountMessages>(responseBody) ?? new rpCountMessages();
                if (rp.success)
                {
                    Console.WriteLine("Messages count correctly");
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

        private HubConnection hubConnection;
        public rpConsultMessages rpConsultMessages { get; set; }
        private async void InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{GlobalVariables.url}chathub").Build();

            hubConnection.On<rpConsultMessages>("ReceiveMessages", (incominggMessage)  => 
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => addMessageAsync(incominggMessage)));
                }
                else 
                {
                    addMessageAsync(incominggMessage);
                }
            });

            await hubConnection.StartAsync();
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        private async void addMessageAsync(rpConsultMessages rpConsultMessages) 
        {
            messagesCount = await countMessages(userName, receiver);
            page = (int)Math.Ceiling((double)messagesCount / 7);
            page = (page == 0) ? 1 : page;
            await consultMessages(userName, receiver, 7, page);
        }

        string nombre;
        private void insertLocalLastMessages(string lastMessage) 
        {
            foreach (Control control in container!.Controls) 
            {
                
                if (control.Name == "panelUsers") 
                {
                    foreach(Control control2 in control.Controls) 
                    {
                        if (control2.Name == "FriendsList")
                        {
                            FriendsList friendList = (FriendsList)control2;
                            
                            foreach (Control flpC in friendList.Controls)
                            {
                                if (flpC.GetType() == typeof(FlowLayoutPanel))
                                {
                                    foreach (Control userItem in flpC.Controls) 
                                    {
                                        UserItem usitem = (UserItem)userItem;
                                        if (usitem.usernameFriend == receiver)
                                        {
                                            usitem.description = lastMessage;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }



            //foreach (var control in container!.Controls)
            //{
            //    if (control.GetType() == typeof(FlowLayoutPanel))
            //    {
            //        FlowLayoutPanel flp = (FlowLayoutPanel)control;
            //        foreach (var userItem in flp.Controls)
            //        {
            //            if (userItem.GetType() == typeof(UserItem))
            //            {
            //                UserItem usitem = (UserItem)userItem;
            //                if (usitem.usernameFriend == receiver)
            //                {
            //                    usitem.description = lastMessage;
            //                }
            //            }
            //        }

                //    }
                //}
        }
        
        private async Task registerFriendship(string usernameFirst, string usernameSecond) 
        {
            try
            {
                string urlPost = "api/darkmsgs/registerFriendship";
                rqAddFriendship rqCountMessages = new rqAddFriendship() { usernameFirst = usernameFirst, usernameSecond = usernameSecond };
                var rqSerialized = JsonSerializer.Serialize(rqCountMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpAddFriendship rp = JsonSerializer.Deserialize<rpAddFriendship>(responseBody) ?? new rpAddFriendship();
                if (rp.success)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => {
                            tlpMessagesChat.Controls.Clear();
                            container!.flpQueryUserInitializer();
                        } ));
                        
                    }
                    else
                    {
                        tlpMessagesChat.Controls.Clear();
                        container!.flpQueryUserInitializer();
                    }
                }
                else
                {
                    MessageBox.Show($"Error. {rp.message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }


        private async void messageCellAddFriendClick(object sender, EventArgs e)
        {
            await registerFriendship(userName, receiver);
        }

        private void AddFriendButton()
        {
            MessageCell messageCell = new MessageCell();
            messageCell.TextAlign = ContentAlignment.MiddleCenter;
            messageCell.Title = "Add Friend";
            messageCell.Description = "";
            messageCell.Click += messageCellAddFriendClick!;
            tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
        }
    }



}
