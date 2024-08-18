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
        public Dictionary<string, Bitmap> options = new Dictionary<string, Bitmap>
        {
            {"User Information", Properties.Resources.profile_information_24638},
            {"Update Password", Properties.Resources.change_password_5_64},
            {"Update Username", Properties.Resources.user_solid }  
        };


        private string[] optionsName = {"Update Password", "Update Username"};
        private Bitmap[] icons = 
        {
            Properties.Resources.change_password_5_64,
            Properties.Resources.user_solid,
        };
        public AccountInformationForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
        }

        private void AccountInformationForm_Load(object sender, EventArgs e)
        {
            loadOptions();
        }

        private void loadOptions() 
        {
            foreach (KeyValuePair<string, Bitmap> option in options) 
            {
                OptionItem optionItem = new OptionItem();
                optionItem.name = option.Key;
                optionItem.container = container;
                optionItem.mainPage = mainPage;
                optionItem.icon = option.Value;
                optionItem.Enabled = (option.Key != "User Information") ? true : false;
                flpOptions.Controls.Add(optionItem);
            }

        }
    }
}
