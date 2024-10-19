using DarkMessages.models.Chats;
using DarkMessages.models.Groups;
using DarkMessages.models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using DarkMessages.DesktopApp.personalizedComponents.shared;

namespace DarkMessages.DesktopApp
{
    public partial class GroupMemberOptionsForm : Form
    {
        public chat chat { get; set; }
        public int groupId { get; set; }
        public Container container { get; set; }
        public GroupSettingsForm groupSettingsForm { get; set; }
        public bool isAdmin { get; set; }
        HttpClient client = new HttpClient();
        public GroupMemberOptionsForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GroupMemberOptionsForm_Load(object sender, EventArgs e)
        {
            lblGroupMember.Text = chat.name;
            if(!isAdmin) btnRemove.Enabled = false;
            if(container.user.Id == chat.entityId) btnRemove.Visible = false;
        }

        private async Task removeGroupMember()
        {
            try
            {
                string urlPost = "api/darkmsgs/removeGroupMember";
                rqRemoveGroupMember rqRemoveGroupMember = new rqRemoveGroupMember() { groupId = groupId, userId = container.user.Id, userIdRemove = chat.entityId };
                var rqSerialized = JsonSerializer.Serialize(rqRemoveGroupMember);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRemoveGroupMember rp = JsonSerializer.Deserialize<rpRemoveGroupMember>(responseBody) ?? new rpRemoveGroupMember();
                if (rp.success)
                {
                    this.DialogResult = DialogResult.OK;                    
                    Close();

                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");

            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            ConfirmDialog confirmDialog = new ConfirmDialog();
            confirmDialog.predicateText = "Remove member";
            confirmDialog.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = confirmDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await removeGroupMember();
            }
        }
    }
}
