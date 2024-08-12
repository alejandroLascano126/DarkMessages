using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Notifications
{
    public class Notification
    {
        public int notificationId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string receiverUsername { get; set; }
        public int typeId { get; set; }
        public string infoJson { get; set; }
        public DateTime deateCreated { get; set; }
    }
}
