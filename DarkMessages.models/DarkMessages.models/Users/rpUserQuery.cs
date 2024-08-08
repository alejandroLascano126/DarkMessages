using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Usuarios
{
    public class rpUserQuery : BaseResponse
    {
        public List<User> users { get; set; }
    }
}
