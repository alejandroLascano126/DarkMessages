using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Chats
{
    public class rpConsultChats : BaseResponse
    {
        public List<chat> chats { get; set; }
    }
}
