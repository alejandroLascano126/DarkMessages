using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Notifications
{
    public class rqMantNotifications
    {
        public string username { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
        public int notificationId { get; set; }
        public string option { get; set; }
    }
}
