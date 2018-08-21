using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F6 : StreamFuction
    {
        public S7F6()
        {
            this.CODE_NAME = "S7, F6 Process Program Data (PPD)";
            this.DESCRIPTION = @"Equipment reply to host-originated S7,F6. Used to upload process programs from the equipment to
                                   the host.";
        }
    }
}
