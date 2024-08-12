using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Usuarios
{
    public class rqUserQuery
    {
        public string value { get; set; }
        public string username { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
        public string option { get; set; }
        
    }
}
