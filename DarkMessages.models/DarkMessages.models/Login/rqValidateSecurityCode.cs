using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Login
{
    public class rqValidateSecurityCode
    {
        public int idUser { get; set; }
        public int securityCode { get; set; }
        public string opt { get; set; }
    }
}
