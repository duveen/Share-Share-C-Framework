using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F14 : StreamFuction
    {
        public S1F14()
        {
            this.CODE_NAME = "S1, F14 Establish Communications Request Acknowledge (CRA)";
            this.DESCRIPTION = "Equipment reply to host-originated S1,F13.";
        }
    }
}
