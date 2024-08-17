using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Token
{
    public class RqValidateToken
    {
        public int idUser { get; set; }
        public int securityCode { get; set; }
        public string opt { get; set; }
    }
}
