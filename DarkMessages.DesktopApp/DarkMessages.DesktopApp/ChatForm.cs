using DarkMessages.models.Login;
using DarkMessages.models.Message;
using DarkMessages.models.SignUp;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarkMessages.DesktopApp
{
    public partial class ChatForm : Form
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string receiver { get; set; }
        public List<models.Message> messages { get; set; }
        public Container? container { get; set; }
        HttpClient client = new HttpClient();
        public ChatForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            lblNameChat.Text = name;
            await consultMessages(userName, receiver, 20,1);


        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            InitializeTableLayoutPanel();
            

            //if (messages != null)
            //{
            //    foreach (models.Message message in messages)
            //    {
            //        AddMessage(message.message, message.time, message.isLeftAligned);
            //    }
            //}
            //else 
            //{
            //    if (tlpMessagesChat.Controls.Count > 0) 
            //    {
            //        tlpMessagesChat.Controls.Clear();
            //    }
            //    AddMessage("Hola que tal", "11:30", true);
            //    AddMessage("Me llamo Sofia", "11:31", false);
            //    AddMessage("Hola me llamo Alex", "11:32", true);
            //    AddMessage("Adios", "11:33", false);
            //}

            if (rtbSendMessage.Text != null && rtbSendMessage.Text != "") 
            {
                AddMessage(rtbSendMessage.Text, "11:34",false);
                await sendMessage(userName, receiver, rtbSendMessage.Text);
            }
        }

        private int currentRow = 0;
        private void AddMessage(string message, string time, bool isLeftAligned)
        {
            //tlpMessagesChat.RowCount = currentRow + 1;
            //tlpMessagesChat.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            

            MessageCell messageCell = new MessageCell();
            messageCell.Title = message;
            messageCell.Description = time;


            if (isLeftAligned)
            {
                tlpMessagesChat.Controls.Add(messageCell, 0, currentRow); // Añadir a la columna izquierda
            }
            else
            {
                tlpMessagesChat.Controls.Add(messageCell, 1, currentRow); // Añadir a la columna derecha
                messageCell.Anchor = AnchorStyles.Right;
            }
            currentRow++;
        }

        private void InitializeTableLayoutPanel()
        {
            //tlpMessagesChat.ColumnCount = 2;
            //tlpMessagesChat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            //tlpMessagesChat.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));            
            //tlpMessagesChat.RowStyles.Add(new RowStyle(SizeType.Absolute, 20)); // Fijar altura de las filas            
        }

        private async Task sendMessage(string sender, string receiver, string message) 
        {
            try
            {
                string urlPost = "api/darkmsgs/insertMessage";
                rqInsertMessage rqInsertMessage = new rqInsertMessage() {senderUser = userName, receiverUser = receiver, messageContent = message };
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
                    foreach (var message in rp.messages) 
                    {
                        AddMessage(message.messageContent, message.createdAt.ToString("HH:mm"), (message.senderUser == userName) ? false : true) ;
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
