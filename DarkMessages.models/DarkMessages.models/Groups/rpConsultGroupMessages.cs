using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rpConsultGroupMessages : BaseResponse
    {
        public List<groupMessage> messages { get; set; }
    }
}
