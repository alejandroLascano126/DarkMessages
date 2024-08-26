using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Login
{
    public class rpLogin : BaseResponse
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public byte[]? profilePicture { get; set; }
    }
}
