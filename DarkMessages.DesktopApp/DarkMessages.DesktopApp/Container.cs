using DarkMessages.models.Login;
using System.Xml.Serialization;

namespace DarkMessages.DesktopApp
{
    public partial class Container : Form
    {
        public string username { get; set; } = "alejandro";
        public Container()
        {
            InitializeComponent();
            LoginUserPageInitializer();
            //MainPageInitializer();
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

        public void SecurityCodePageInitializer(int idUser, string username, string password, string? otp) 
        {
            this.username = username;
            SecurityCodeForm securityCodeForm = new SecurityCodeForm();
            securityCodeForm.idUser = idUser;
            securityCodeForm.username = username;
            securityCodeForm.password = password;
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

        public void MainPageInitializer() 
        {
            MainPage mainPage = new MainPage();
            mainPage.container = this;
            mainPage.TopLevel = false;
            mainPage.Dock = DockStyle.Fill;
            Controls.Add(mainPage);
            Tag = mainPage;
            mainPage.Size = Size;
            mainPage.Show();
        }
    }
}
