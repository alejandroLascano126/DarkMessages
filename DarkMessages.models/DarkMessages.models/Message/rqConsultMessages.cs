﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkMessages.models.Message
{
    public class rqConsultMessages
    {
        public string usernameSender { get; set; }
        public string usernameReceiver { get; set; }
        public int rows { get; set; }
        public int page { get; set; }
    }
}
