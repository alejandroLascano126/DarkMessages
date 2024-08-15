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
    public partial class AccountInformationForm : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public User user { get; set; }
        public MainPage mainPage { get; set; }
        public AccountInformationForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }



        
    }
}
