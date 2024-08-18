using DarkMessages.DesktopApp.Helpers;
using DarkMessages.models.Chats;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
using DarkMessages.models.Users;
using DarkMessages.models.Usuarios;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;


namespace DarkMessages.DesktopApp
{
    public partial class UpdatePasswordForm : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public User user { get; set; }
        public MainPage mainPage { get; set; }
        public UpdatePasswordForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private async Task UpdateUserInfo()
        {
            try
            {
                string urlPost = "api/darkmsgs/updateUserInfo";
                rqUpdUserInfo rq = new rqUpdUserInfo();
                rq.userId = user.Id;
                rq.password = txtNewPassword.Text;
                rq.actualPassword = txtPassword.Text;
                var rqSerialized = System.Text.Json.JsonSerializer.Serialize(rq);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpUpdUserInfo rpUpdUserInfo = JsonConvert.DeserializeObject<rpUpdUserInfo>(responseBody) ?? new rpUpdUserInfo();
                if (rpUpdUserInfo.success)
                {
                    MessageBox.Show("Password updated. " + rpUpdUserInfo.message);
                }
                else
                {
                    MessageBox.Show(rpUpdUserInfo.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error. {ex}");
            }

        }

        private async void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPassword.Text) &&
                !string.IsNullOrEmpty(txtNewRePassword.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text)
            )
            {
                if (txtNewRePassword.Text == txtNewPassword.Text)
                {
                    bool resp = await mainPage.SecurityCodeSettingsFormInitializerAsync("Account_info");
                    if (resp)
                    {
                        await UpdateUserInfo();
                    }
                }
                else
                {
                    MessageBox.Show("Different new passwords");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            mainPage.AccouuntInformationFormInitializer();
        }
    }
}
