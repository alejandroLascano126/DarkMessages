﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Groups
{
    public class rpConsultGroupMembers : BaseResponse
    {
        public List<groupMember> groupMembers { get; set; }
    }
}
