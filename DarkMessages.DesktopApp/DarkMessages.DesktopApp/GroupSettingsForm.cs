using DarkMessages.models.Chats;
using DarkMessages.models.Friends;
using DarkMessages.models.Groups;
using DarkMessages.models.Notifications;
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
    public partial class GroupSettingsForm : Form
    {
        public chat chat { get; set; }
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        public groupMember groupMember { get; set; }
        HttpClient client = new HttpClient();
        private string usernameSelected { get; set; }
        private int rows = 5;
        private int page = 1;
        private int groupMembersCount = 0;
        private int maxPage = 0;
        private int minPage = 1;
        private string optionConsulting = "ALL";

        public GroupSettingsForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private async void GroupSettingsForm_Load(object sender, EventArgs e)
        {
            groupMembersCount = await countGroupMembers();
            maxPage = (int)Math.Ceiling((double)groupMembersCount / rows);
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
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat.entityId, rows = rows, page = page, option = "ALL", value = "" };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    if (rp.groupMembers.Count > 0)
                    {
                        if (flpContacts.Controls.Count > 0)
                        {
                            flpContacts.Controls.Clear();
                        }
                    }
                    foreach (var user in rp.groupMembers)
                    {

                        chat chat = new chat() { entityId = user.idUser, name = user.name + " " + user.lastname ?? "", friendUsername = user.username ?? "", email = user.email };
                        UserItem item = new UserItem();
                        item.name = user.name + " " + user.lastname;
                        item.description = user.roleId == 1 ? "Member" : "Administrator";
                        item.username = container.user.userName;
                        item.chat = chat;
                        item.groupMemberInfo = user;
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
            string filterValue = txtSelectedContact.Text;
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMembers";
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat.entityId, rows = rows, page = 1, option = "FIL", value = filterValue };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    if (flpContacts.Controls.Count > 0)
                    {
                        flpContacts.Controls.Clear();
                    }
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
            optionConsulting = "FIL";
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
                    groupMembersCount = await countGroupMembers();
                    maxPage = (int)Math.Ceiling((double)groupMembersCount / rows);
                    optionConsulting = "ALL";
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

        private async void txtSelectedContact_Click(object sender, EventArgs e)
        {
            lblContacts.Text = "Contacts";
            if (flpContacts.Controls.Count > 0)
            {
                flpContacts.Controls.Clear();
            }
            await consultAddMembers();
        }

        private async void txtSelectedContact_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSelectedContact.Text))
                await consultAddMembers();
        }

        private async void FlpContacts_MouseWheel(object sender, MouseEventArgs e)
        {
            if (optionConsulting == "ALL")
            {
                groupMembersCount = await countGroupMembers();
                if (groupMembersCount > rows)
                {
                    if (e.Delta > 0) //up
                    {
                        if (pageScrollHelp(--page))
                            await consultMembers();
                    }
                    else //down
                    {
                        if (pageScrollHelp(++page))
                            await consultMembers();
                    }
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

        private async Task<int> countGroupMembers()
        {
            string contactUsername = txtSelectedContact.Text;
            try
            {
                string urlPost = "api/darkmsgs/consultGroupMembers";
                rqConsultGroupMembers rqConsultGroupMembers = new rqConsultGroupMembers() { groupId = chat.entityId, option = "CNT", value = "" };
                var rqSerialized = JsonSerializer.Serialize(rqConsultGroupMembers);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpConsultGroupMembers rp = JsonSerializer.Deserialize<rpConsultGroupMembers>(responseBody) ?? new rpConsultGroupMembers();
                if (rp.success)
                {
                    return Int32.Parse(rp.message);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return 0;
            }
        }

        public async void showGroupMembersOptionsForm(chat chat)
        {
            Form overlay = new Form();
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.ShowInTaskbar = false;
            overlay.BackColor = Color.Black;
            overlay.Opacity = 0.2;
            overlay.StartPosition = FormStartPosition.Manual;
            overlay.Location = mainPage.PointToScreen(Point.Empty);
            overlay.Size = mainPage.Size;
            overlay.Show(mainPage);



            GroupMemberOptionsForm groupMemberOptionsForm = new GroupMemberOptionsForm();
            groupMemberOptionsForm.chat = chat;
            groupMemberOptionsForm.groupId = this.chat.entityId;
            groupMemberOptionsForm.container = container;
            groupMemberOptionsForm.isAdmin = groupMember.roleId == 2 ? true : false;
            groupMemberOptionsForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = groupMemberOptionsForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                groupMembersCount = await countGroupMembers();
                maxPage = (int)Math.Ceiling((double)groupMembersCount / rows);
                optionConsulting = "ALL";
                await consultMembers();
            }
            overlay.Close();
        }

        private async void btnLeaveGroup_Click(object sender, EventArgs e)
        {
            await LeaveGroup();
        }

        private async Task LeaveGroup()
        {
            try
            {
                string urlPost = "api/darkmsgs/removeGroupMember";
                rqRemoveGroupMember rqRemoveGroupMember = new rqRemoveGroupMember() { groupId = chat.entityId, userId = container.user.Id, userIdRemove = container.user.Id };
                var rqSerialized = JsonSerializer.Serialize(rqRemoveGroupMember);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRemoveGroupMember rp = JsonSerializer.Deserialize<rpRemoveGroupMember>(responseBody) ?? new rpRemoveGroupMember();
                if (rp.success)
                {
                    Close();
                    clearCacheData();
                    mainPage.ChatFormInitializer(null, null, true, false, null, null, null);
                    mainPage.colorSelectedButton("Chats");
                    mainPage.flpItemsUserInitializer();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");

            }
        }

        private void clearCacheData() 
        {
            GlobalVariables.chat = null;
            GlobalVariables.isFriend = null;
            GlobalVariables.notification = null;
            GlobalVariables.notificationsList = null;
            GlobalVariables.username = container!.user.userName;
            GlobalVariables.isFriendRequest = null;
            GlobalVariables.isRequestSent = null;
            GlobalVariables.chatType = ChatType.privateChat;
        }
    }
}
