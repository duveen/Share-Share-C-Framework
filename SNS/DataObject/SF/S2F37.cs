﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F37 : StreamFuction
    {
        public S2F37()
        {
            this.CODE_NAME = "S2, F37 Enable/Disable Event Report (EDER)";
            this.DESCRIPTION = "Used by the host to enable or disable specific event reports on the equipment.";
            this.STRUCTURE = @"<L[2]
    <BL[1]> * CEED
    <L[N]
        <U2[1]> * CEID1
        .
        .
        .
        <U2[1]> * CEIDN
    >
>";
            this.DetailContents.Add("CEED", @"Collection event enable/disable code.
FALSE = Disable
TRUE = Enable");
            this.DetailContents.Add("CEID", @"Collection event ID");
        }
    }
}
