﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber_CORE.Response
{
    public class BaseResponse
    {
        public bool Succssed { get; set; }
        public string Massage { get; set; }

        public BaseResponse()
        {
            Succssed = true;
        }
    }
}
