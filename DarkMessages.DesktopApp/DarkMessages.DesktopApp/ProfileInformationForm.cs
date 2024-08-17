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

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text != GlobalVariables.name || txtLastname.Text != GlobalVariables.lastname
                || txtEmail.Text != GlobalVariables.email) 
            {
                mainPage.SecurityCodeSettingsFormInitializer();
            }
        }
    }
}
