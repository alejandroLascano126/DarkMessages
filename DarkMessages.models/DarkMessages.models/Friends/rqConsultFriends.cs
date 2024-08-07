using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Friends
{
    public class rqConsultFriends
    {
        public string username { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
        public string option { get; set; }
    }
}
