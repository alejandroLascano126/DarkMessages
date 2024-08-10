using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class groupMember
    {
        public int idUser { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }
    }
}
