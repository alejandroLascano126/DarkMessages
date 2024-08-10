using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rqRegisterGroupMessages
    {
        public string username { get; set; }
        public int groupId { get; set; }
        public string messageContent { get; set; }
    }
}
