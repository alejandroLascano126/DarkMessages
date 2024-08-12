using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Friends
{
    public class rpConsultfriendshipsRequests : BaseResponse
    {
        public List<friendshipsRequests> friendshipsRequests { get; set; }
    }
}
