﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S5F1 : StreamFuction
    {
        public S5F1()
        {
            this.CODE_NAME = "S5, F1 Alarm Report Send (ARS)";
            this.DESCRIPTION = "Report change in or presence of an alarm condition.";
        }
    }
}
