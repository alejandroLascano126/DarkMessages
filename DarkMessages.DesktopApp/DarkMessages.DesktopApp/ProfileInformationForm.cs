using DarkMessages.DesktopApp.Helpers;
using DarkMessages.models.Chats;
using DarkMessages.models.Login;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
using DarkMessages.models.Users;
using DarkMessages.models.Usuarios;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;


namespace DarkMessages.DesktopApp
{
    public partial class ProfileInformationForm : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public User user { get; set; }
        public MainPage mainPage { get; set; }
        public bool isAuthenticated { get; set; } = false;
        public ProfileInformationForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private void ProfileInformationForm_Load(object sender, EventArgs e)
        {
            txtName.Text = GlobalVariables.name;
            txtLastname.Text = GlobalVariables.lastname;
            txtEmail.Text = GlobalVariables.email;
        }

        private async void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text != GlobalVariables.name || txtLastname.Text != GlobalVariables.lastname
                || txtEmail.Text != GlobalVariables.email) 
            {
                bool resp = await mainPage.SecurityCodeSettingsFormInitializerAsync("Profile_info");
                if (resp) 
                {
                    await UpdateUserInfo();
                }
                else 
                {
                   
                }
            }
        }

        private async Task UpdateUserInfo()
        {
            try
            {
                string urlPost = "api/darkmsgs/updateUserInfo";
                rqUpdUserInfo rq = new rqUpdUserInfo();
                rq.userId = user.Id;
                rq.name = txtName.Text;
                rq.lastname = txtLastname.Text;
                var rqSerialized = System.Text.Json.JsonSerializer.Serialize(rq);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpUpdUserInfo rpUpdUserInfo = JsonConvert.DeserializeObject<rpUpdUserInfo>(responseBody) ?? new rpUpdUserInfo();
                if (rpUpdUserInfo.success)
                {
                    MessageBox.Show(rpUpdUserInfo.message);
                    GlobalVariables.name = txtName.Text;
                    GlobalVariables.lastname = txtLastname.Text;
                }
                else
                {
                    MessageBox.Show(rpUpdUserInfo.message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error. {ex}");
            }

        }

    }
}
