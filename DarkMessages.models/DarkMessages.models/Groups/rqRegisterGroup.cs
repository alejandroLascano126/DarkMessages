
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rqRegisterGroup
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool isPublic { get; set; }
        public string photo { get; set; }
    }
}
