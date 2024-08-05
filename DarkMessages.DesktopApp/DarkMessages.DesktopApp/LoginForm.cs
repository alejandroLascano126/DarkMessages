using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkMessages.models.Login;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Timers;


namespace DarkMessages.DesktopApp
{
    public partial class LoginForm : Form
    {
        public Container? container { get; set; }
        HttpClient client = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ValidaUsernamePassword();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Close();
            container!.RegisterUserPageInitializer();
        }

        private async Task ValidaUsernamePassword() 
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;
            try
            {
                string urlPost = "api/darkmsgs/ValidaUsernamePassword";
                rqLogin rqLogin = new rqLogin() { username = username, password = password, securityCode = 000000 };
                var rqLoginSerialized = JsonSerializer.Serialize(rqLogin);
                HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseBody);
                bool success = Convert.ToBoolean(jsonResponse["success"]);
                string message = Convert.ToString(jsonResponse["message"]) ?? "";
                if (success)
                {
                    Close();
                    MessageBox.Show(message);
                    int id = Convert.ToInt32(jsonResponse["id"]);
                    container!.SecurityCodePageInitializer(id, username, password, "login_user");
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has ocurred! {ex}");
            }

        }
    }
}
