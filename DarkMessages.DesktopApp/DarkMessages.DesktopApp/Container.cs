using DarkMessages.DesktopApp.Helpers;
using DarkMessages.models.Chats;
using DarkMessages.models.Login;
using DarkMessages.models.Session;
using DarkMessages.models.Usuarios;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarkMessages.DesktopApp
{
    public partial class Container : Form
    {
        public User user { get; set; }
        HttpClient client = new HttpClient();
        public Container()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            //LoginUserPageInitializer();
            SessionSaved();
        }


        public void LoginUserPageInitializer()
        {
            LoginForm loginForm = new LoginForm
            {
                container = this,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            Controls.Add(loginForm);
            Tag = loginForm;
            loginForm.Size = Size;
            loginForm.Show();
        }

        public void SecurityCodePageInitializer(User user, string? otp)
        {
            this.user = user;
            SecurityCodeForm securityCodeForm = new SecurityCodeForm();
            securityCodeForm.user = user;
            securityCodeForm.opt = (otp != null) ? otp : null;
            securityCodeForm.container = this;
            securityCodeForm.TopLevel = false;
            securityCodeForm.Dock = DockStyle.Fill;
            Controls.Add(securityCodeForm);
            Tag = securityCodeForm;
            securityCodeForm.Size = Size;
            securityCodeForm.Show();
        }

        public void RegisterUserPageInitializer()
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.container = this;
            registerForm.TopLevel = false;
            registerForm.Dock = DockStyle.Fill;
            Controls.Add(registerForm);
            Tag = registerForm;
            registerForm.Size = Size;
            registerForm.Show();
        }

        public void MainPageInitializer(User? user)
        {
            if (this.user == null && user != null)
                this.user = user!;
            MainPage mainPage = new MainPage();
            mainPage.container = this;
            mainPage.user = this.user!;
            mainPage.TopLevel = false;
            mainPage.Dock = DockStyle.Fill;
            Controls.Add(mainPage);
            Tag = mainPage;
            mainPage.Size = Size;
            mainPage.Show();
        }

        private async void SessionSaved()
        {
            bool resp = await LoginSession();
            if (resp)
            {
                int id = GlobalVariables.userId;
                string username = GlobalVariables.lastUsername;
                string name = GlobalVariables.name;
                string lastname = GlobalVariables.lastname;
                user = new User() { Id = id, userName = username, name = name, lastname = lastname };
                MainPageInitializer(user);
            }
            else
            {
                LoginUserPageInitializer();
            }
        }

        private async Task<bool> LoginSession()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.lastUsername))
            {
                try
                {
                    string ip = ConnectionHelper.getMachineIp();

                    string urlPost = "api/darkmsgs/LoginSession";
                    rqLoginSession rqLogin = new rqLoginSession() { ip_name = ip, username = GlobalVariables.lastUsername, saveSession = true, option = "LOG" };
                    var rqLoginSerialized = JsonSerializer.Serialize(rqLogin);
                    HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(urlPost, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    rpLoginSession rpLoginSession = JsonSerializer.Deserialize<rpLoginSession>(responseBody) ?? new rpLoginSession();
                    if (rpLoginSession.success)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        private async void Container_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(user != null)
                 await SetOnlineStatus();
        }


        private async Task SetOnlineStatus()
        {
            string ip = ConnectionHelper.getMachineIp();
            try
            {
                string urlPost = "api/darkmsgs/MantSession";
                rqMantSession rqMantSession = new rqMantSession() { username = user.userName ?? "", option = "UPD", ipName = ip, onlineStatus = false };
                var rqSerialized = JsonSerializer.Serialize(rqMantSession);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpMantSession rp = JsonSerializer.Deserialize<rpMantSession>(responseBody) ?? new rpMantSession();
                if (rp.success)
                {
                    
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

        //public void SettingsFormInitializer() 
        //{
        //    SettingsForm settingsForm = new SettingsForm();
        //    settingsForm.container = this;
        //    settingsForm.user = user;
        //    settingsForm.TopLevel = false;
        //    settingsForm.Dock = DockStyle.Fill;
        //    this.Controls.Add(settingsForm);
        //    this.Tag = settingsForm;
        //    settingsForm.Size = this.Size;
        //    settingsForm.Show();
        //}
    }
}
