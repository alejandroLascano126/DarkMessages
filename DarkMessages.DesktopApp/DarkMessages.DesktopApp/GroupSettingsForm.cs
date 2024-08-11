using DarkMessages.models.Chats;
using DarkMessages.models.Groups;
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
    public partial class GroupSettingsForm : Form
    {
        public chat chat { get; set; }
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        HttpClient client = new HttpClient();
        private string usernameSelected { get; set; }

        public GroupSettingsForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private async void GroupSettingsForm_Load(object sender, EventArgs e)
        {
            lblResponseMessage.Text = "";
            txtTitle.Text = chat.name;
            txtDescription.Text = chat.description;
            await consultMembers();
        }

        private async Task consultMembers()
        {
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMembers";
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat.entityId, rows = 10, page = 1, option = "ALL" };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    foreach (var user in rp.groupMembers)
                    {
                        chat chat = new chat() { name = user.name ?? "", friendUsername = user.username ?? "", email = user.email };
                        UserItem item = new UserItem();
                        item.name = user.name ?? "";
                        item.description = "";
                        item.username = container.user.userName;
                        item.chat = chat;
                        item.usernameFriend = user.username ?? "";
                        item.groupSettingsForm = this;
                        item.groupMember = true;
                        //item.isFriend = user.isFriend;
                        item.isContact = true;
                        item.container = mainPage;
                        flpContacts.Controls.Add(item);
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


        private async Task consultAddMembers()
        {
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMembers";
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat.entityId, rows = 10, page = 1, option = "ADD" };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    Console.WriteLine("Friends consulted correctly");
                    foreach (var user in rp.groupMembers)
                    {
                        chat chat = new chat() { name = user.name + " " + user.lastname ?? "", friendUsername = user.username ?? "", email = user.email };
                        UserItem item = new UserItem();
                        item.name = user.name + " " + user.lastname ?? "";
                        item.description = "";
                        item.username = container.user.userName;
                        item.chat = chat;
                        item.groupSettingsForm = this;
                        item.groupMember = false;
                        item.groupMember = false;
                        item.usernameFriend = user.username ?? "";
                        //item.isFriend = user.isFriend;
                        item.isContact = true;
                        item.container = mainPage;
                        flpContacts.Controls.Add(item);
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

        private async void btnViewContacts_Click(object sender, EventArgs e)
        {
            lblContacts.Text = "Contacts";
            if (flpContacts.Controls.Count > 0)
            {
                flpContacts.Controls.Clear();
            }
            await consultAddMembers();
        }

        public void AsignData(chat chat)
        {
            txtSelectedContact.Text = chat.name;
            usernameSelected = chat.friendUsername ?? "";
        }

        private async Task RegisterGroupMember()
        {
            string contactUsername = txtSelectedContact.Text;
            try
            {
                string urlPost = "api/darkmsgs/registerGroupMember";
                rqRegisterGroupMember rqRegisterGroupMember = new rqRegisterGroupMember() { groupId = chat.entityId, username = usernameSelected, roleId = 1 };
                var rqSerialized = JsonSerializer.Serialize(rqRegisterGroupMember);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRegisterGroupMember rp = JsonSerializer.Deserialize<rpRegisterGroupMember>(responseBody) ?? new rpRegisterGroupMember();
                if (rp.success)
                {
                    txtSelectedContact.Text = "";
                    usernameSelected = "";
                    lblResponseMessage.Text = "User registered in the group";
                    if (flpContacts.Controls.Count > 0)
                    {
                        flpContacts.Controls.Clear();
                    }
                    lblContacts.Text = "Members";
                    await consultMembers();
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

        private async void btnAddContact_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(usernameSelected))
                await RegisterGroupMember();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainPage.ChatFormGroupInitializer(container.user.userName, chat);
        }
    }
}
