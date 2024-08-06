using DarkMessages.DesktopApp.models;
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
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;




namespace DarkMessages.DesktopApp
{
    public partial class ChatForm : Form
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string receiver { get; set; }
        public List<DarkMessages.models.Message.message> messages { get; set; }
        public Container? container { get; set; }
        HttpClient client = new HttpClient();

        public ChatForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            InitializeSignalR();
            
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            lblNameChat.Text = name;

            //int messagesCount = await countMessages(userName, receiver);
            //int page = messagesCount / 10;
            messages = new List<DarkMessages.models.Message.message>() { };
            await consultMessages(userName, receiver, 7, 1);


        }




        private async void btnSendMessage_Click(object sender, EventArgs e)
        {

            if (rtbSendMessage.Text != null && rtbSendMessage.Text != "")
            {
                //AddMessage(rtbSendMessage.Text, DateTime.Now.ToString("HH:ss"), false);
                await sendMessage(userName, receiver, rtbSendMessage.Text);
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
                tlpMessagesChat.Controls.Add(messageCell, 1, currentRow);
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
                    Console.WriteLine("Message consulted correctly");
                    DarkMessages.models.Message.message msg = new DarkMessages.models.Message.message();
                    msg = rp.messages.Last(); // last new message
                    if (rp.messages.Count - messages.Count == 1) // a new message received
                    {
                        AddMessage(msg.messageContent, msg.createdAt.ToString("HH:mm"), (msg.senderUser == userName) ? false : true);
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
            await consultMessages(userName, receiver, 7, 1);
            //DarkMessages.models.Message.message message = new DarkMessages.models.Message.message();
            //message = rpConsultMessages.messages.Last();

            //AddMessage(message.messageContent, message.createdAt.ToString("HH:mm"), (message.senderUser == userName) ? false : true);
        }


    }



}
