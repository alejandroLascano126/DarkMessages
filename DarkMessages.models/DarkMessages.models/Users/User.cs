using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Usuarios
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string countryId { get; set; }
        public string country { get; set; }
        public string languages { get; set; }
        public string email { get; set; }
        public string lastDevice { get; set; }
    }
}
