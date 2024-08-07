using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DarkMessages.models.Login;
using System.Text.Json;
using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;

namespace DarkMessages.DesktopApp
{
    public partial class SecurityCodeForm : Form
    {
        private HttpClient client = new HttpClient();
        public int idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? opt { get; set; }
        public Container container { get; set; }
        private int contadorTimer = 59;
        public SecurityCodeForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            initTimerCodigoValida();
        }

        private async void btnSecurityCode_ClickAsync(object sender, EventArgs e)
        {

            await ValidateSecurityCode();
        }

        private void txtSecurityCode_Click(object sender, EventArgs e)
        {

        }

        private void initTimerCodigoValida()
        {
            btnReSendSecurityCode.Enabled = false;
            timerCodigoValida.Enabled = true;
            timerCodigoValida.Interval = 1000;
            timerCodigoValida.Tick += new EventHandler(changeTiempoCodigoValida!);
            timerCodigoValida.Start();

        }


        private void changeTiempoCodigoValida(Object myObject, EventArgs myEventArgs)
        {
            if (contadorTimer == 0)
            {
                timerCodigoValida.Stop();
                btnReSendSecurityCode.Enabled = true;
            }
            lblTimerCodigoValida.Text = $"00:{(contadorTimer--).ToString("D2")}";
        }

        private async void btnReSendSecurityCode_ClickAsync(object sender, EventArgs e)
        {
            await ResendSecurityCode();
        }



        private async Task ValidateSecurityCode()
        {
            try
            {
                int securityCode = Convert.ToInt32(txtSecurityCode.Text);
                string urlPost = "api/darkmsgs/ValidateSecurityCode";
                rqValidateSecurityCode rq = new rqValidateSecurityCode();
                rq.idUser = idUser;
                rq.securityCode = securityCode;
                rq.opt = "";
                var rqSerialized = JsonSerializer.Serialize(rq);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseBody);
                bool success = Convert.ToBoolean(jsonResponse["success"]);
                string message = Convert.ToString(jsonResponse["message"]) ?? "";
                if (success)
                {
                    MessageBox.Show(message);
                    Close();
                    if (opt != null)
                    {
                        if (opt == "register_user")
                        {
                            container.LoginUserPageInitializer();
                        }
                        else if (opt == "login_user")
                        {
                            container.MainPageInitializer();
                        }
                    }
                    // Redirect to the main message chat
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch
            {
                MessageBox.Show("Insert numbers");
            }

        }

        private async Task ResendSecurityCode()
        {
            string urlPost = "api/darkmsgs/ResendSecurityCode";
            rqLogin rq = new rqLogin();
            rq.username = username;
            rq.password = password;
            var rqSerialized = JsonSerializer.Serialize(rq);
            HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(urlPost, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseBody);
            bool success = Convert.ToBoolean(jsonResponse["success"]);
            string message = Convert.ToString(jsonResponse["message"]) ?? "";
            if (success)
            {
                contadorTimer = 59;
                initTimerCodigoValida();
            }
            else
            {
                MessageBox.Show("Error al reenviar codigo de seguridad");
            }
        }

        private void btnBackSecCode_Click(object sender, EventArgs e)
        {
            Close();
            container.LoginUserPageInitializer();
        }
    }
}
