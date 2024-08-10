using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class group
    {
        public int groupId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string isPublic { get; set; }
        public string photo { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime? dateUpdated { get; set; }
    }
}
