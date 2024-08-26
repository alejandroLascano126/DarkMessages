using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rqRemoveGroupMember
    {
        public int groupId { get; set; }
        public int userId { get; set; }
        public int userIdRemove { get; set; }
    }
}
