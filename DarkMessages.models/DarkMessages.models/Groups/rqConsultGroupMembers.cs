using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rqConsultGroupMembers
    {
        public int groupId { get; set;}
        public int rows { get; set;}
        public int page { get; set; }
        public string option { get; set; }
        public string value { get; set; }
    }
}
