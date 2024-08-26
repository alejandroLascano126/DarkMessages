using DarkMessages.DesktopApp.Helpers;
using DarkMessages.models.Chats;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
using DarkMessages.models.Usuarios;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;


namespace DarkMessages.DesktopApp
{
    public partial class SettingsForm : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public User user { get; set; }
        public MainPage mainPage { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        private async Task<bool> QuitSession()
        {
            if (!string.IsNullOrEmpty(GlobalVariables.lastUsername))
            {
                try
                {
                    string ip = ConnectionHelper.getMachineIp();

                    string urlPost = "api/darkmsgs/LoginSession";
                    rqLoginSession rqLogin = new rqLoginSession() { ip_name = ip, username = GlobalVariables.lastUsername, saveSession = true, option = "DEL" };
                    var rqLoginSerialized = JsonSerializer.Serialize(rqLogin);
                    HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(urlPost, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    rpLoginSession rpLoginSession = JsonSerializer.Deserialize<rpLoginSession>(responseBody) ?? new rpLoginSession();
                    if (rpLoginSession.success)
                    {
                        string AppSettingsjsonPath = "appSettings.json";
                        string jsonString = File.ReadAllText(AppSettingsjsonPath);
                        Root? root = JsonSerializer.Deserialize<Root>(jsonString);

                        root.appSettings.lastUsername = "";
                        root.appSettings.userId = 0;
                        root.appSettings.name = "";
                        root.appSettings.lastname = "";

                        container.user = null;

                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string updatedJsonText = JsonSerializer.Serialize(root, options);
                        File.WriteAllText(AppSettingsjsonPath, updatedJsonText);

                        GlobalVariables.lastUsername = "";
                        GlobalVariables.userId = 0;
                        GlobalVariables.name = "";
                        GlobalVariables.lastname = "";
                        GlobalVariables.username = null;
                        GlobalVariables.chat= null;
                        GlobalVariables.isFriend= null;
                        GlobalVariables.isFriendRequest= null;
                        GlobalVariables.notification= null;
                        GlobalVariables.isRequestSent= null;
                        GlobalVariables.notificationsList= null;
                        GlobalVariables.chatType = null;
                        GlobalVariables.profilePicture = null;

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

        private async void btnQuitSession_Click(object sender, EventArgs e)
        {
            bool resp = await QuitSession();
            if (resp)
            {
                mainPage.Close();
                container.LoginUserPageInitializer();
            }
            else 
            {
                MessageBox.Show("Session wasn't quit");
            }
        }
    }
}
