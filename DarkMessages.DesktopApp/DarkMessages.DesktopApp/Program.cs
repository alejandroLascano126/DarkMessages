using System;
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
           
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Container());
        }
    }

    public static class GlobalVariables
    {
        public static string url { get; set; }
    }
}