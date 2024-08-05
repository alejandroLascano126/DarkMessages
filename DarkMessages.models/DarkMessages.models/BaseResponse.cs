using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models
{
    public abstract class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
