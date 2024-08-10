using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.DesktopApp.Helpers
{
    public static class ConnectionHelper
    {
        public static string getMachineIp() 
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(hostName);
            IPAddress primaryIpAddress = null;
            foreach (var ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ipAddress))
                {
                    primaryIpAddress = ipAddress;
                    break;
                }
            }

            if (primaryIpAddress != null)
            {
                return primaryIpAddress.ToString();
            }
            return string.Empty;
        }
    }
}
