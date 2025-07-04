﻿using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Login;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
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
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;




namespace DarkMessages.DesktopApp
{
    public partial class ChatFormPrivate : Form
    {
        public string userName { get; set; }
        public bool isFriend { get; set; }
        public chat chat { get; set; }
        private bool isInputDisabled { get; set; } = false;
        private HubConnection hubConnection;
        public rpConsultMessages rpConsultMessages { get; set; }
        private List<DarkMessages.models.Message.message> messages { get; set; }
        public MainPage? container { get; set; }
        public bool isFriendRequest { get; set; } = false;
        public bool isRequestSent { get; set; } = false;
        public Notification? notification { get; set; }
        public NotificationsList? notificationsList { get; set; }
        HttpClient client = new HttpClient();
        private int page;
        private int lastPage;
        private int messagesCount;
        private int currentRow = 0;
        private int maxPage = 0;
        private int minPage = 1;
        private int rows = 8;

        private int itemHeight = 69;
        private Size lastsize = new Size();

        public ChatFormPrivate()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            InitializeSignalR();
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.chat != null)
            {
                chat = GlobalVariables.chat;
                isFriend = GlobalVariables.isFriend ?? false;
                userName = GlobalVariables.username ?? string.Empty;
            }


            lblNameChat.Text = chat.name;
            lblOnlineStatus.Text = "";

            messagesCount = await countMessages(userName, chat.friendUsername ?? "");
            page = (int)Math.Ceiling((double)messagesCount / rows);            
            page = (page == 0) ? 1 : page;
            lastPage = page;
            maxPage = (int)Math.Ceiling((double)messagesCount / rows);
            messages = new List<DarkMessages.models.Message.message>() { };

            if (!isFriend)
            {
                AddFriendButton();
                disableInputChatForm();
            }

            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(chat.friendUsername) && string.IsNullOrEmpty(chat.name))
            {
                disableInputChatForm();
            }

            if (!isInputDisabled)
            {
                await ConsultOnlineStatus();
                await consultMessages(userName, chat.friendUsername ?? "", rows, page);
            }


            if (notification != null)
            {
                if (notification.typeId == 2 || notification.typeId == 3)
                {
                    if (await deleteNotification())
                        notificationsList!.loadNewAsync();
                }
            }

            saveStateCache();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {

            if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
            {
                await sendMessage(userName, chat.friendUsername ?? "", rtbSendMessage.Text);

                rtbSendMessage.Text = "";
            }
        }

        private void AddMessage(string message, string time, bool isLeftAligned)
        {
            MessageCell messageCell = new MessageCell();
            messageCell.Title = message;
            messageCell.Description = time;

            if (isLeftAligned)
            {
                tlpMessagesChat.Controls.Add(messageCell, 0, currentRow);
                messageCell.Anchor = AnchorStyles.Left;
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
                rqInsertMessage rqInsertMessage = new rqInsertMessage() { senderUser = userName, receiverUser = receiver, messageContent = message, email = chat.email ?? "" };
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
                        if (lastPage != page) currentRow = 0;
                        if (messages == null) messages = new List<message>();

                        Console.WriteLine("Message consulted correctly");
                        DarkMessages.models.Message.message msg = new DarkMessages.models.Message.message();
                        msg = rp.messages.Last(); // last new message
                        if (rp.messages.Count - messages.Count == 1) // a new message received
                        {
                            if (currentRow < messages.Count) currentRow = messages.Count;
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
                        lastPage = page;
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

        private async void InitializeSignalR()
        {
            hubConnection = new HubConnectionBuilder().WithUrl($"{GlobalVariables.url}chathub").Build();

            hubConnection.On<rpConsultMessages>("ReceiveMessages", (incominggMessage) =>
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

            hubConnection.On<rpMantSession>("ReceiveUsersOnlineStatus", (incominggMessage) =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => ConsultOnlineStatusAsync()));
                }
                else
                {
                    ConsultOnlineStatusAsync();
                }
            });

            await hubConnection.StartAsync();
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        private async void addMessageAsync(rpConsultMessages rpConsultMessages)
        {
            if (!isInputDisabled)
            {
                messagesCount = await countMessages(userName, chat.friendUsername ?? "");
                maxPage = (int)Math.Ceiling((double)messagesCount / rows);
                page = maxPage;
                page = (page == 0) ? 1 : page;
                await consultMessages(userName, chat.friendUsername ?? "", rows, page);
            }
        }

        private void insertLocalLastMessages(string lastMessage)
        {
            foreach (Control control in container!.Controls)
            {
                if (control.Name == "panelUsers")
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (control2.Name == "ChatList")
                        {
                            ChatList friendList = (ChatList)control2;

                            foreach (Control flpC in friendList.Controls)
                            {
                                if (flpC.GetType() == typeof(FlowLayoutPanel))
                                {
                                    foreach (Control userItem in flpC.Controls)
                                    {
                                        UserItem usitem = (UserItem)userItem;
                                        if (usitem.chat.friendUsername == chat.friendUsername)
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
        }

        private async Task<bool> consultRegisterFriendship(string usernameFirst, string usernameSecond, string option)
        {
            try
            {
                string urlPost = "api/darkmsgs/registerFriendship";
                rqAddFriendship rqCountMessages = new rqAddFriendship() { usernameFirst = usernameFirst, usernameSecond = usernameSecond, option = option };
                var rqSerialized = JsonSerializer.Serialize(rqCountMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpAddFriendship rp = JsonSerializer.Deserialize<rpAddFriendship>(responseBody) ?? new rpAddFriendship();
                if (rp.success)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            if (option == "REG")
                            {
                                tlpMessagesChat.Controls.Clear();
                                container!.flpQueryUserInitializer();
                                enableInputChatForm();
                            }

                        }));

                    }
                    else
                    {
                        if (option == "REG")
                        {
                            tlpMessagesChat.Controls.Clear();
                            container!.flpQueryUserInitializer();
                            enableInputChatForm();
                        }
                    }
                    return rp.success;
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
            return false;
        }


        private async void messageCellAddFriendClick(object sender, EventArgs e)
        {
            bool resp = await consultRegisterFriendship(userName, chat.friendUsername ?? "", "CON");
            if (resp)
            {
                tlpMessagesChat.Controls.Clear();
                MessageCell messageCell = new MessageCell();
                messageCell.TextAlign = ContentAlignment.MiddleCenter;
                messageCell.Title = "Request sent";
                messageCell.Description = "";
                tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
            }
        }

        private async void messageCellAcceptFriendRequest(object sender, EventArgs e)
        {
            if (notification != null)
            {
                if (await deleteNotification())
                {
                    await consultRegisterFriendship(userName, chat.friendUsername ?? "", "REG");
                }
            }
        }

        private void AddFriendButton()
        {
            if (isFriendRequest)
            {
                MessageCell messageCell = new MessageCell();
                messageCell.TextAlign = ContentAlignment.MiddleCenter;
                messageCell.Title = "Accept request";
                messageCell.Description = "";
                messageCell.Click += messageCellAcceptFriendRequest!;
                tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
            }
            else
            {
                if (isRequestSent)
                {
                    MessageCell messageCell = new MessageCell();
                    messageCell.TextAlign = ContentAlignment.MiddleCenter;
                    messageCell.Title = "Request sent";
                    messageCell.Description = "";
                    tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
                }
                else
                {
                    MessageCell messageCell = new MessageCell();
                    messageCell.TextAlign = ContentAlignment.MiddleCenter;
                    messageCell.Title = "Send request";
                    messageCell.Description = "";
                    messageCell.Click += messageCellAddFriendClick!;
                    tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
                }
            }
        }

        public void disableInputChatForm()
        {
            lblOnlineStatus.Enabled = false;
            btnSendMessage.Enabled = false;
            rtbSendMessage.Enabled = false;
            isInputDisabled = true;
        }

        public void enableInputChatForm()
        {
            btnSendMessage.Enabled = true;
            rtbSendMessage.Enabled = true;
            isInputDisabled = false;
        }


        private async void TlpMessagesChat_MouseWheel(object sender, MouseEventArgs e)
        {
            currentRow = 0;
            if (messagesCount > rows)
            {
                if (e.Delta > 0) //up
                {
                    if (pageScrollHelp(--page))
                        await consultMessages(userName, chat.friendUsername ?? "", rows, page);
                }
                else //down
                {
                    if (pageScrollHelp(++page))
                        await consultMessages(userName, chat.friendUsername ?? "", rows, page);
                }
            }
        }

        private async void rtbSendMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
                {
                    await sendMessage(userName, chat.friendUsername ?? "", rtbSendMessage.Text);

                    rtbSendMessage.Text = "";
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

        public async Task<bool> deleteNotification()
        {
            try
            {
                string urlPost = "api/darkmsgs/mantNotifications";
                rqMantNotifications rqMantNotifications = new rqMantNotifications() { username = container!.user.userName, rows = 0, page = 0, notificationId = notification!.notificationId, option = "DEL" };
                var rqSerialized = JsonSerializer.Serialize(rqMantNotifications);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpMantNotifications rp = JsonSerializer.Deserialize<rpMantNotifications>(responseBody) ?? new rpMantNotifications();
                if (rp.success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error. DeleteNotificaion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
            return false;
        }

        private void saveStateCache()
        {
            if (!string.IsNullOrEmpty(chat.name))
            {
                GlobalVariables.chat = chat;
                GlobalVariables.isFriend = isFriend;
                GlobalVariables.notification = notification;
                GlobalVariables.notificationsList = notificationsList;
                GlobalVariables.username = container!.user.userName;
                GlobalVariables.isFriendRequest = isFriendRequest;
                GlobalVariables.isRequestSent = isRequestSent;
                GlobalVariables.chatType = ChatType.privateChat;
            }
        }

        private async Task ConsultOnlineStatus()
        {
            try
            {
                string urlPost = "api/darkmsgs/MantSession";
                rqMantSession rqMantSession = new rqMantSession() { username = chat.friendUsername ?? "", option = "CON", onlineStatus = true };
                var rqSerialized = JsonSerializer.Serialize(rqMantSession);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpMantSession rp = JsonSerializer.Deserialize<rpMantSession>(responseBody) ?? new rpMantSession();
                if (rp.success)
                {
                    if (rp.sessions.Count > 0)
                    {
                        Invoke(() => lblOnlineStatus.Text = "Online");
                    }
                    else
                    {
                        Invoke(() => lblOnlineStatus.Text = "Offline");
                    }
                }
                else
                {
                    MessageBox.Show("Error.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private async void ConsultOnlineStatusAsync()
        {
            if (!isInputDisabled)
                await ConsultOnlineStatus();
        }

        private async void tlpMessagesChat_ClientSizeChanged(object sender, EventArgs e)
        {
            if ((Size.Height == 648 || Size.Height == 609) && lastsize.Height == 0)
                return;
            else if (lastsize.Height == 0)
                lastsize.Height = 609;

            messagesCount = await countMessages(userName, chat.friendUsername ?? "");
            page = 1;
            currentRow = 0;
            if (lastsize.Height < Size.Height)
            {
                int difference = (int)(Size.Height - lastsize.Height);
                if (difference > itemHeight)
                {
                    lastsize = Size;
                    int rowsPlus = difference / itemHeight;
                    rows += rowsPlus;
                    maxPage = (int)Math.Ceiling((double)messagesCount / rows);
                    page = maxPage;
                    await consultMessages(userName, chat.friendUsername ?? "", rows, page);
                }
            }
            else
            {
                int difference = (int)(Size.Height - lastsize.Height);
                if (difference < itemHeight)
                {
                    lastsize = Size;
                    int rowsMinus = difference / itemHeight;
                    rows += rowsMinus;
                    maxPage = (int)Math.Ceiling((double)messagesCount / rows);
                    page = maxPage;
                    await consultMessages(userName, chat.friendUsername ?? "", rows, page);
                }
            }
        }
    }



}
