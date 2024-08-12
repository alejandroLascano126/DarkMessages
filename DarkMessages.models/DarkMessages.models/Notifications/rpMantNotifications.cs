using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Notifications
{
    public class rpMantNotifications : BaseResponse
    {
        public List<Notification> notifications { get; set; }
        public int count { get; set; }
    }
}
