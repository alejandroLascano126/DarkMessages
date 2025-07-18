﻿using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Groups;
using DarkMessages.models.Login;
using DarkMessages.models.Message;
using DarkMessages.models.Notifications;
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
    public partial class ChatFormGroup : Form
    {
        public string? userName { get; set; }
        public chat? chat { get; set; }
        private bool isInputDisabled { get; set; } = false;
        private HubConnection hubConnection;
        public rpConsultMessages rpConsultMessages { get; set; }
        private List<groupMessage> messages { get; set; }
        public MainPage? container { get; set; }
        HttpClient client = new HttpClient();
        private int page;
        private int lastPage;
        private int messagesCount;
        private int currentRow = 0;
        private int rows = 6;
        private int maxPage = 0;
        private int minPage = 1;

        private int itemHeight = 50;
        private Size lastsize = new Size();

        private groupMember userGroupMember;
        public ChatFormGroup()
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
                userName = GlobalVariables.username!;
            }

            lblNameChat.Text = chat!.name;
            messages = new List<groupMessage>() { };
            messagesCount = await countGroupMessages();
            page = (int)Math.Ceiling((double)messagesCount / rows);
            page = (page == 0) ? 1 : page;
            maxPage = (int)Math.Ceiling((double)messagesCount / rows);

            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(chat.friendUsername) && string.IsNullOrEmpty(chat.name))
            {
                disableInputChatForm();
            }
            if (!isInputDisabled)
                await consultMessages(rows, page);

            saveStateCache();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {

            if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
            {
                await sendMessage(userName!, chat!.entityId, rtbSendMessage.Text);

                rtbSendMessage.Text = "";
            }
        }

        private void AddMessage(string message, string time, bool isLeftAligned, string? nameUser)
        {


            if (isLeftAligned)
            {
                GroupMessageCell messageCell = new GroupMessageCell();
                messageCell.Title = message;
                messageCell.Description = time;
                messageCell.NameUser = nameUser ?? "";
                tlpMessagesChat.Controls.Add(messageCell, 0, currentRow);
                messageCell.Anchor = AnchorStyles.Left;
            }
            else
            {
                MessageCell messageCell = new MessageCell();
                messageCell.Title = message;
                messageCell.Description = time;
                tlpMessagesChat.Controls.Add(messageCell, 2, currentRow);
                messageCell.Anchor = AnchorStyles.Right;
            }
            currentRow++;
        }




        private async Task sendMessage(string sender, int groupId, string message)
        {
            try
            {
                string urlPost = "api/darkmsgs/registerGroupMessages";
                rqRegisterGroupMessages rqRegisterGroupMessages = new rqRegisterGroupMessages() { username = sender, groupId = groupId, messageContent = message };
                var rqSerialized = JsonSerializer.Serialize(rqRegisterGroupMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRegisterGroupMessages rp = JsonSerializer.Deserialize<rpRegisterGroupMessages>(responseBody) ?? new rpRegisterGroupMessages();
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


        private async Task consultMessages(int rows, int page)
        {
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMessages";
                rqConsultGroupMessages rqConsultMessages = new rqConsultGroupMessages() { groupId = chat!.entityId, rows = rows, page = page };
                var rqSerialized = JsonSerializer.Serialize(rqConsultMessages);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMessages rp = JsonSerializer.Deserialize<rpConsultGroupMessages>(responseBody) ?? new rpConsultGroupMessages();
                if (rp.success)
                {
                    if (rp.messages.Count > 0)
                    {
                        if (lastPage != page) currentRow = 0;
                        if (messages == null) messages = new List<groupMessage>();
                        Console.WriteLine("Message consulted correctly");
                        groupMessage msg = new groupMessage();
                        msg = rp.messages.Last(); // last new message
                        if (rp.messages.Count - messages.Count == 1) // a new message received
                        {
                            if (currentRow < messages.Count) currentRow = messages.Count;
                            AddMessage(msg.messageContent, msg.dateCreated.ToString("HH:mm"), (msg.username == container!.user.userName) ? false : true, $"{msg.name} {msg.lastname}");
                            insertLocalLastMessages(msg.messageContent);
                        }
                        else //many new messages
                        {
                            //insertLocalLastMessages(msg.messageContent);
                            tlpMessagesChat.Controls.Clear();
                            foreach (var message in rp.messages)
                            {
                                AddMessage(message.messageContent, message.dateCreated.ToString("HH:mm"), (message.username == container!.user.userName) ? false : true, $"{message.name} {message.lastname}");
                            }
                            messages.Clear();
                        }

                        messages = rp.messages;
                    }
                }
                else
                {
                    //MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex}");
            }

        }

        private async Task<int> countGroupMessages()
        {
            try
            {
                string urlPost = "api/darkmsgs/countGroupMessages";
                rqCountGroupMessages rqCountGroupMessages = new rqCountGroupMessages() { groupId = chat!.entityId };
                var rqSerialized = JsonSerializer.Serialize(rqCountGroupMessages);
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

            hubConnection.On<rpConsultGroupMessages>("ReceiveGroupMessages", (incominggMessage) =>
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

        private async void addMessageAsync(rpConsultGroupMessages rpConsultGroupMessages)
        {
            if (!isInputDisabled)
            {
                messagesCount = await countGroupMessages();
                page = (int)Math.Ceiling((double)messagesCount / rows);
                page = (page == 0) ? 1 : page;
                await consultMessages(rows, page);
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
                                        if (usitem.name == chat!.name)
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

        public void disableInputChatForm()
        {
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

        private async void panelUpChat_Click(object sender, EventArgs e)
        {
            await consultUserGroupMember();
            container!.GroupSettingsFormInitializer(chat!, userGroupMember);
        }

        private async void TlpMessagesChat_MouseWheel(object sender, MouseEventArgs e)
        {
            currentRow = 0;
            if (messagesCount > rows)
            {
                if (e.Delta > 0) //up
                {
                    if (pageScrollHelp(--page))
                        await consultMessages(rows, page);
                }
                else //down
                {
                    if (pageScrollHelp(++page))
                        await consultMessages(rows, page);
                }
            }
        }

        private async void rtbSendMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
                {
                    await sendMessage(userName!, chat!.entityId, rtbSendMessage.Text);

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

        private void saveStateCache()
        {
            if (!string.IsNullOrEmpty(chat!.name))
            {
                GlobalVariables.chat = chat;
                GlobalVariables.username = container!.user.userName;
                GlobalVariables.chatType = ChatType.groupChat;
            }
        }

        private async void tlpMessagesChat_ClientSizeChanged(object sender, EventArgs e)
        {
            if ((Size.Height == 648 || Size.Height == 609) && lastsize.Height == 0)
                return;
            else if (lastsize.Height == 0)
                lastsize.Height = 609;

            messagesCount = await countGroupMessages();
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
                    await consultMessages(rows, page);
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
                    await consultMessages(rows, page);
                }
            }
        }

        private async Task consultUserGroupMember()
        {
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMember";
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat!.entityId, rows = rows, page = page, option = "ALL", value = container!.user.Id.ToString() };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    userGroupMember = rp.groupMembers.FirstOrDefault() ?? new groupMember();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }
    }



}
