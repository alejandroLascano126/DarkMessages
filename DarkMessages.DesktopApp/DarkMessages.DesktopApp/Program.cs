using System;
using System.Net.NetworkInformation;
using DarkMessages.models.Chats;
using DarkMessages.models.Notifications;
using Microsoft.Extensions.Configuration;

namespace DarkMessages.DesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            GlobalVariables.url = configuration["appSettings:url"]!;
            GlobalVariables.emailValidation = Convert.ToBoolean(configuration["appSettings:emailValidation"]!);
            GlobalVariables.lastUsername = configuration["appSettings:lastUsername"]!;
            GlobalVariables.userId = Convert.ToInt32(configuration["appSettings:userId"]!);
            GlobalVariables.name = configuration["appSettings:name"]!;
            GlobalVariables.lastname = configuration["appSettings:lastname"]!;
            GlobalVariables.email = configuration["appSettings:email"]!;
            GlobalVariables.isDevelopment = Convert.ToBoolean(configuration["appSettings:isDevelopment"]!);
            string base64String = configuration["appSettings:profilePicture"] ?? "";
            if (!string.IsNullOrEmpty(base64String))
            {
                byte[] profilePictureBytes = Convert.FromBase64String(base64String);
                GlobalVariables.profilePicture = profilePictureBytes;
            }
            else 
            {
                GlobalVariables.profilePicture = null;
            }
              



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Container());
        }
    }

    public static class GlobalVariables
    {
        public static string url { get; set; }
        public static bool emailValidation { get; set;}
        public static string lastUsername { get; set; }
        public static int userId { get; set; }
        public static string name { get; set; }
        public static string lastname { get; set; }
        public static string? username { get; set; }
        public static chat? chat { get; set; }
        public static bool? isFriend { get; set; }
        public static bool? isFriendRequest { get; set; }
        public static Notification? notification { get; set; }
        public static bool? isRequestSent { get; set; }
        public static NotificationsList? notificationsList { get; set; }
        public static ChatType? chatType { get; set; }
        public static bool isDevelopment { get; set; }
        public static TabType tabType { get; set; }
        public static string email { get; set; }
        public static byte[]? profilePicture { get; set; }
    }

    public enum ChatType{ privateChat, groupChat }
    public enum TabType{ chats, contacts, news, group}
}