﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F38 : StreamFuction
    {
        public S2F38()
        {
            this.CODE_NAME = "S2, F38 Enable/Disable Event Report Acknowledge (EERA)";
            this.DESCRIPTION = @"Acknowledge or error. If an error condition is detected the entire message is rejected (i.e. partial
                                   changes are not allowed).";
        }
    }
}
