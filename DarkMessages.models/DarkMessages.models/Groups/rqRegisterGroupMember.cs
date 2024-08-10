using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rqRegisterGroupMember
    {
        public int groupId { get; set; }
        public string username { get; set; }
        public int roleId { get; set; }
    }
}
