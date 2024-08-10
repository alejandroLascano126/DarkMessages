using DarkMessages.models.Login;
using DarkMessages.models.Usuarios;
using System.Xml.Serialization;

namespace DarkMessages.DesktopApp
{
    public partial class Container : Form
    {
        public User user { get; set; }
        public Container()
        {
            InitializeComponent();
            LoginUserPageInitializer();
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

        public void SecurityCodePageInitializer(User user, string? otp) 
        {
            this.user = user;
            SecurityCodeForm securityCodeForm = new SecurityCodeForm();
            securityCodeForm.user = user;
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

        public void MainPageInitializer(User? user) 
        {
            if(this.user == null && user != null)
                this.user = user!;
            MainPage mainPage = new MainPage();
            mainPage.container = this;
            mainPage.user = user!;
            mainPage.TopLevel = false;
            mainPage.Dock = DockStyle.Fill;
            Controls.Add(mainPage);
            Tag = mainPage;
            mainPage.Size = Size;
            mainPage.Show();
        }
    }
}
