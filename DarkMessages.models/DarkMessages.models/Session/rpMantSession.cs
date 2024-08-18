using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Session
{
    public class rpMantSession : BaseResponse
    {
        public List<session> sessions { get; set; }
    }
}
