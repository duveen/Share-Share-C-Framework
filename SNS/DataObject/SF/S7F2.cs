using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F2 : StreamFuction
    {
        public S7F2()
        {
            this.CODE_NAME = "S7, F2 Process Program Load Grant (PPG)";
            this.DESCRIPTION = @"Equipment reply to host-originated S7,F1. Used to acknowledge or reject host request to download
                                   multi-block process program.";
        }
    }
}
