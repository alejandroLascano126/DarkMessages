﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Message
{
    public class rpConsultMessages : BaseResponse
    {
        public List<message> messages { get; set; }
    }
}
