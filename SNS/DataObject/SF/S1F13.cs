using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F13 : StreamFuction
    {
        public S1F13()
        {
            this.CODE_NAME = "S1, F13 Establish Communications Request (CR)";
            this.DESCRIPTION = "Used by the host to attempt to initialize communications with the equipment.";
        }
    }
}
