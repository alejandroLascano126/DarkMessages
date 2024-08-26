using DarkMessages.DesktopApp.Helpers;
using DarkMessages.models.Chats;
using DarkMessages.models.Login;
using DarkMessages.models.Notifications;
using DarkMessages.models.Session;
using DarkMessages.models.Users;
using DarkMessages.models.Usuarios;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DarkMessages.DesktopApp
{
    public partial class ProfileInformationForm : Form
    {
        HttpClient client = new HttpClient();
        public Container container { get; set; }
        public User user { get; set; }
        public MainPage mainPage { get; set; }
        public bool isAuthenticated { get; set; } = false;
        private OpenFileDialog openFileDialog;
        private byte[]? profilePicture { get; set; }
        public ProfileInformationForm()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);
            openFileDialog = new OpenFileDialog();
        }

        private void ProfileInformationForm_Load(object sender, EventArgs e)
        {
            txtName.Text = GlobalVariables.name;
            txtLastname.Text = GlobalVariables.lastname;
            txtEmail.Text = GlobalVariables.email;
            profilePicture = GlobalVariables.profilePicture ?? null;
            if (profilePicture != null) 
              picBoxProfilePicture.Image = ImageHelper.ConvertBytesToImage(profilePicture);
        }

        private async void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text != GlobalVariables.name || txtLastname.Text != GlobalVariables.lastname
                || txtEmail.Text != GlobalVariables.email || profilePicture != GlobalVariables.profilePicture)
            {
                bool resp = await mainPage.SecurityCodeSettingsFormInitializerAsync("Profile_info");
                if (resp)
                {
                    await UpdateUserInfo();
                    picBoxProfilePicture.Image = ImageHelper.ConvertBytesToImage(GlobalVariables.profilePicture!);
                }
                else
                {

                }
            }
        }

        private async Task UpdateUserInfo()
        {
            try
            {
                string urlPost = "api/darkmsgs/updateUserInfo";
                rqUpdUserInfo rq = new rqUpdUserInfo();
                rq.userId = user.Id;
                rq.name = txtName.Text;
                rq.lastname = txtLastname.Text;
                rq.profilePicture = GlobalVariables.profilePicture;
                var rqSerialized = System.Text.Json.JsonSerializer.Serialize(rq);
                HttpContent content = new StringContent(rqSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlPost, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                rpUpdUserInfo rpUpdUserInfo = JsonConvert.DeserializeObject<rpUpdUserInfo>(responseBody) ?? new rpUpdUserInfo();
                if (rpUpdUserInfo.success)
                {
                    //MessageBox.Show(rpUpdUserInfo.message);
                    GlobalVariables.name = txtName.Text;
                    GlobalVariables.lastname = txtLastname.Text;
                    GlobalVariables.profilePicture = profilePicture;

                    string AppSettingsjsonPath = "appSettings.json";
                    string jsonString = File.ReadAllText(AppSettingsjsonPath);
                    Root? root = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonString);

                    root.appSettings.profilePicture = GlobalVariables.profilePicture!;

                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string updatedJsonText = System.Text.Json.JsonSerializer.Serialize(root, options);
                    File.WriteAllText(AppSettingsjsonPath, updatedJsonText);
                }
                else
                {
                    MessageBox.Show(rpUpdUserInfo.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error. {ex}");
            }

        }

        private void btbUpdatePhoto_Click(object sender, EventArgs e)
        {
            setProfilePicture();
        }

        private void setProfilePicture() 
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image resizedImage = ImageHelper.ResizeImage(Image.FromFile(filePath), 200, 200);
                picBoxProfilePicture.Image = resizedImage;

                //profilePicture = ConvertImageToBytes(resizedImage);
                GlobalVariables.profilePicture = ImageHelper.ConvertImageToBytes(resizedImage);
                //await UpdateUserInfo();
            }
        }

        

    }
}
