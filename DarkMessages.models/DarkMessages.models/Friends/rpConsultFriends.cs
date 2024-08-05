using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Friends
{
    public class rpConsultFriends : BaseResponse
    {
        public List<Friend> friends { get; set; }
    }
}
