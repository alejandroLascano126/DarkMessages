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
using DarkMessages.models.Usuarios;
using DarkMessages.models.Token;
using Newtonsoft.Json;

namespace DarkMessages.DesktopApp
{
    public partial class SecurityCodeSettingsForm : Form
    {
        private HttpClient client = new HttpClient();
        public User user { get; set; }
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        private int contadorTimer = 59;
        public SecurityCodeSettingsForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            //initTimerCodigoValida();
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
            rpSendToken rpSendToken = await ResendSecurityCode();
        }

        private async Task ValidateSecurityCode()
        {
            try
            {
                int securityCode = Convert.ToInt32(txtSecurityCode.Text);
                string urlPost = "api/darkmsgs/ValidateSecurityCode";
                rqValidateSecurityCode rq = new rqValidateSecurityCode();
                rq.idUser = user.Id;
                rq.securityCode = securityCode;
                rq.opt = "";
                var rqSerialized = System.Text.Json.JsonSerializer.Serialize(rq);
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
                    mainPage.ProfileInformationFormInitializer();
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

        private async Task<rpSendToken> ResendSecurityCode()
        {
            rpSendToken rp = new rpSendToken();
            string urlPost = "api/darkmsgs/SendSecurityCode";
            rqSendToken rq = new rqSendToken();
            rq.email = GlobalVariables.email;
            rq.userId = user.Id;
            var rqSerialized = System.Text.Json.JsonSerializer.Serialize(rq);
            HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(urlPost, content);
            string responseBody = await response.Content.ReadAsStringAsync();
            rp = JsonConvert.DeserializeObject<rpSendToken>(responseBody)!;
            if (rp.success)
            {
                contadorTimer = 59;
                initTimerCodigoValida();
            }
            else
            {
                MessageBox.Show("Error al reenviar codigo de seguridad");
            }
            return rp;
        }

        private void btnBackSecCode_Click(object sender, EventArgs e)
        {
            Close();
            container.LoginUserPageInitializer();
        }

        private async void SecurityCodeSettingsForm_Load(object sender, EventArgs e)
        {
            await ResendSecurityCode();
        }
    }
}
