﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkMessages.models.Login;
using DarkMessages.models.Usuarios;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Timers;
using DarkMessages.models.Session;
using DarkMessages.DesktopApp.Helpers;




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
                rqLogin rqLogin = new rqLogin() { username = username, password = password, securityCode = 000000, emailValidation = GlobalVariables.emailValidation };
                var rqLoginSerialized = JsonSerializer.Serialize(rqLogin);
                HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpLogin rpLogin = JsonSerializer.Deserialize<rpLogin>(responseBody) ?? new rpLogin();
                if (rpLogin.success)
                {
                    int id = Convert.ToInt32(rpLogin.id);
                    User user = new User() { Id = id, userName = username, name = rpLogin.name, lastname = rpLogin.lastname, email = rpLogin.email, profilePicture = rpLogin.profilePicture};
                    InitSession(username, id, rpLogin.name, rpLogin.lastname, rpLogin.email, rpLogin.profilePicture);
                    rpLoginSession resp = await LoginSession(username);
                    if (GlobalVariables.emailValidation)
                    {
                        if (resp.success) 
                        {
                            MessageBox.Show(rpLogin.message);
                            Close();
                            container!.SecurityCodePageInitializer(user, "login_user");
                        }
                        else
                        {
                            MessageBox.Show(resp.message);
                        }

                    }
                    else 
                    {
                        if (resp.success)
                        {
                            MessageBox.Show(rpLogin.message);
                            Close();
                            container!.MainPageInitializer(user);
                        }
                        else 
                        {
                            MessageBox.Show(resp.message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(rpLogin.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has ocurred! {ex}");
            }

        }



        private async Task<rpLoginSession> LoginSession(string username)
        {
            rpLoginSession rpLoginSession = new rpLoginSession();  
            try
            {
                string ip = ConnectionHelper.getMachineIp();

                string urlPost = "api/darkmsgs/LoginSession";
                rqLoginSession rqLogin = new rqLoginSession() { ip_name = ip, username = username, saveSession = true, option = "LOG" };
                var rqLoginSerialized = JsonSerializer.Serialize(rqLogin);
                HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpLoginSession = JsonSerializer.Deserialize<rpLoginSession>(responseBody) ?? new rpLoginSession();
                return rpLoginSession; 
            }
            catch (Exception ex)
            {
                return rpLoginSession;
            }
        }


        public void InitSession(string lastUsername, int userId, string name, string lastname, string email, byte[] profilePicture)
        {
            if (string.IsNullOrEmpty(GlobalVariables.lastUsername))
            {
                string AppSettingsjsonPath = "appSettings.json";
                string jsonString = File.ReadAllText(AppSettingsjsonPath);
                Root? root = JsonSerializer.Deserialize<Root>(jsonString);

                root.appSettings.lastUsername = lastUsername;
                root.appSettings.userId = userId;
                root.appSettings.name = name;
                root.appSettings.lastname = lastname;
                root.appSettings.email = email;
                root.appSettings.profilePicture = profilePicture;

                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJsonText = JsonSerializer.Serialize(root, options);
                File.WriteAllText(AppSettingsjsonPath, updatedJsonText);

                GlobalVariables.lastUsername = lastUsername;
                GlobalVariables.userId = userId;
                GlobalVariables.name = name;
                GlobalVariables.lastname = lastname;
                GlobalVariables.email = email;
                GlobalVariables.profilePicture = profilePicture;
            }
        }
    }



    public class appSettings
    {
        public string url { get; set; }
        public bool emailValidation { get; set; }
        public string lastUsername { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public bool isDevelopment { get; set; }
        public byte[] profilePicture { get; set; }
    }

    public class Root
    {
        public appSettings appSettings { get; set; }
    }
}
