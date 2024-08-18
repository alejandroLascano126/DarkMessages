using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Users
{
    public class rqUpdUserInfo  
    {
        public int userId { get; set; }
        public string? name { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; } 
        public string? username { get; set; }
        public string? password { get; set; }
        public string? actualPassword { get; set; }
    }
}
