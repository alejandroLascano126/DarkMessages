using DarkMessages.models.Friends;
using DarkMessages.models.Groups;
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
    public partial class CreateGroupForm : Form
    {
        public User user { get; set; }
        HttpClient client = new HttpClient();
        public CreateGroupForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        public async Task createGroup()
        {
            try
            {
                string name = txtName.Text;
                string description = txtDescription.Text;
                string urlPost = "api/darkmsgs/registerGroup";
                rqRegisterGroup rqRegisterGroup = new rqRegisterGroup() { name = name, description = description, isPublic = false, photo = "" };
                var rqSerialized = JsonSerializer.Serialize(rqRegisterGroup);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRegisterGroup rp = JsonSerializer.Deserialize<rpRegisterGroup>(responseBody) ?? new rpRegisterGroup();
                if (rp.success)
                {
                    await registerGroupMember(rp.id);
                    lblMensaje.Text = "Group created";
                    txtName.Text = "";
                    txtDescription.Text = "";
                }
                else
                {
                    lblMensaje.Text = $"Error. {rp.message}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }


        private async void btnCreateGroup_Click(object sender, EventArgs e) 
        {
            if (txtName.Text != null && txtName.Text != "" && txtDescription.Text != null && txtDescription.Text != "")
            {
                await createGroup();
            }
            else 
            {
                lblMensaje.Text = "Complete the data";
            }
            
        }


        public async Task registerGroupMember(int groupId)
        {
            try
            {
                string urlPost = "api/darkmsgs/registerGroupMember";
                rqRegisterGroupMember rqRegisterGroup = new rqRegisterGroupMember() { groupId = groupId, username = user.userName, roleId = 2};
                var rqSerialized = JsonSerializer.Serialize(rqRegisterGroup);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpRegisterGroupMember rp = JsonSerializer.Deserialize<rpRegisterGroupMember>(responseBody) ?? new rpRegisterGroupMember();
                if (rp.success)
                {
                    
                }
                else
                {
                    lblMensaje.Text = $"Error. {rp.message}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
            }
        }

        private void CreateGroupForm_Load(object sender, EventArgs e) 
        {
            lblMensaje.Text = "";
        }

    }
}
