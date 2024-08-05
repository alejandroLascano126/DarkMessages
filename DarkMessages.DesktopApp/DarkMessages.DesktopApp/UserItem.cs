using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkMessages.DesktopApp
{
    public partial class UserItem : UserControl
    {

        private string _name;
        private string _description;
        private Image _icon;
        public MainPage container { get; set; }
        public string usernameFriend { get; set; }
        public string username { get; set; }

        public UserItem()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string name
        {
            get { return _name; }
            set { _name = value; lblname.Text = _name; }
        }


        [Category("Custom Props")]
        public string description
        {
            get { return _description; }
            set { _description = value; lblDescripcionItemUser.Text = _description; }

        }

        [Category("Custom Props")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image icon
        {
            get { return icon; }
            set { _icon = value; }
        }


        private void UserItem_MouseLeave(object sender, EventArgs e)    
        {
            this.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void UserItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void UserItem_MouseClick(object sender, MouseEventArgs e)
        {
            List<models.Message> messages = new List<models.Message>();
            models.Message msg1 = new models.Message() {message = "Hola Pablo", time = "11:31", isLeftAligned = true };
            models.Message msg2 = new models.Message() { message = "Hola Sonia", time = "11:32", isLeftAligned = false };
            models.Message msg3 = new models.Message() { message = "Me gustas", time = "11:32", isLeftAligned = true };
            models.Message msg4 = new models.Message() { message = "A mi tambien", time = "11:33", isLeftAligned = false };
            messages.Add(msg1);
            messages.Add(msg2);
            messages.Add(msg3);
            messages.Add(msg4);
            container.ChatFormInitializer(_name, username, usernameFriend);
        }
    }
}
