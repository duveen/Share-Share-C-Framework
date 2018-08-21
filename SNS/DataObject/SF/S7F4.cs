using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F4 : StreamFuction
    {
        public S7F4()
        {
            this.CODE_NAME = "S7, F4 Process Program Acknowledge (PPA)";
            this.DESCRIPTION = @"Equipment reply to host-originated S7,F3. Used to acknowledge or reject process program
                                   downloaded from the host.";
        }
    }
}
