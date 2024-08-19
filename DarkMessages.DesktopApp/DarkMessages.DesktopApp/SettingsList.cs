using DarkMessages.models.Friends;
using DarkMessages.models.Chats;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DarkMessages.DesktopApp.Properties;
using System.Security.Principal;
using System.Resources;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace DarkMessages.DesktopApp
{
    public partial class SettingsList : Form
    {
        public Container container { get; set; }
        public MainPage mainPage { get; set; }
        public Control? panelChat { get; set; }
        private string _value;
        public string value
        {
            get { return value; }
            set { _value = value; loadSettingsList(5, 1, _value); }

        }
        HttpClient client = new HttpClient();
        
        Dictionary<string, Bitmap> settingsItems = new Dictionary<string, Bitmap>() 
        {
            { "Profile Information", Properties.Resources.profile_information_24638},
            { "Account Information", Properties.Resources.vecteezy_user_account_icon_for_your_design_only_21079672},
            { "Privacy", Properties.Resources.pngwinggroup_com},
            { "Friends", Properties.Resources.pngwing_com},
            { "Group", Properties.Resources.multiple_users_silhouette},
            { "Settings", Properties.Resources.more_info_icon}

        };

        List<SettingItem> settingItems = new List<SettingItem>();
        List<string> itemNames = new List<string>();
        private int page = 1;
        private int settingsCount = 6;
        private int rows = 5;
        private int maxPage = 2;
        private int minPage = 1;
        
        public SettingsList()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(GlobalVariables.url);

        }

        private void SettingsList_Load(object sender, EventArgs e)
        {
            itemNames = new List<string>(settingsItems.Keys);
            loadSettingsList(5,1, _value);
        }

        private void loadSettingsList(int rows, int page, string value)
        {
            if (settingItems.Count > 0) 
            {
                settingItems.Clear();
            }
            if (flpSettingsItems.Controls.Count > 0)
            {
                flpSettingsItems.Controls.Clear();
            }
            int maxRows = ((rows * page) > settingsCount) ? settingsCount : (rows * page);
            int minRows = (rows * page) - rows;

            

            if (GlobalVariables.isDevelopment) 
            {
                for (int i = minRows; i < maxRows; i++)
                {
                    SettingItem item = new SettingItem();
                    item.name = itemNames[i];
                    item.icon = settingsItems[itemNames[i]];
                    item.mainPage = mainPage;
                    item.container = container;
                    settingItems.Add(item);
                }
                

                if (!string.IsNullOrEmpty(value))
                {
                    foreach (SettingItem settingItem in settingItems)
                    {
                        if (settingItem.name.Contains(value))
                        {
                            flpSettingsItems.Controls.Add(settingItem);
                        }
                    }
                }
                else
                {
                    foreach (SettingItem settingItem in settingItems)
                    {
                        flpSettingsItems.Controls.Add(settingItem);
                    }
                }
                
            }
            
        }

       

        private void FlpSettingsItem_MouseWheel(object sender, MouseEventArgs e) 
        {
            if (e.Delta > 0) //up
            {
                if (pageScrollHelp(--page))
                    loadSettingsList(rows, page, _value);
            }
            else //down
            {
                if (pageScrollHelp(++page))
                    loadSettingsList(rows, page, _value);
            }
        }

        private bool pageScrollHelp(int value)
        {
            if (value < minPage)
            {
                page = 1;
                return false;
            }
            if (value > maxPage)
            {
                page--;
                return false;
            }
            return true;
        }
    }
}
