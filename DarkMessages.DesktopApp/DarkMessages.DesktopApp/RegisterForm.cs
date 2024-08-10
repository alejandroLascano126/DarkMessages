using DarkMessages.models.Login;
using DarkMessages.models.SignUp;
using DarkMessages.models.Usuarios;
using Newtonsoft.Json.Linq;
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
    public partial class RegisterForm : Form
    {
        public Container? container { get; set; }
        HttpClient client = new HttpClient();

        public RegisterForm()
        {
            InitializeComponent();
            LoadLanguages();
            LoadCountries();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private void LoadLanguages() 
        {
            cbLanguages.DropDownStyle= ComboBoxStyle.DropDownList;
            cbLanguages.DataSource = new string[] { "Español", "English" };
        }

        private void LoadCountries() 
        {
            cbCountry.DataSource = new string[] { "Colombia", "Ecuador", "Peru" };
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void btnRegisterUser_Click(object sender, EventArgs e)
        {
            await RegisterUser();
        }

        private void btnBackRegister_Click(object sender, EventArgs e)
        {
            Close();
            container!.LoginUserPageInitializer();
        }

        private async Task RegisterUser() 
        {
            string username = txtRusername.Text;
            string password = txtRpassword.Text;
            string email = txtRemail.Text;
            string language = cbLanguages!.SelectedItem!.ToString() ?? "Español";
            string country = cbCountry!.SelectedItem!.ToString() ?? "Ecuador";
            string name = txtName.Text;
            string lastname = txtLastname.Text;
            try 
            {
                string urlPost = "api/darkmsgs/RegisterUser";
                rqSignUp rqSignUp = new rqSignUp() { userName = username, password = password, email = email, languages = language, country = country, name = name, lastname = lastname };
                var rqLoginSerialized = JsonSerializer.Serialize(rqSignUp);
                HttpContent content = new StringContent(rqLoginSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpSignUp rp = JsonSerializer.Deserialize<rpSignUp>(responseBody) ?? new rpSignUp();
                if (rp.success)
                {
                    Close();
                    MessageBox.Show(rp.message);
                    User user = new User() {Id = rp.id, userName = username, password = password };
                    container!.SecurityCodePageInitializer(user, "register_user");
                }
                else 
                {
                    MessageBox.Show(rp.message);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"An error has ocurred! {ex}");
            }
        }
    }
}
