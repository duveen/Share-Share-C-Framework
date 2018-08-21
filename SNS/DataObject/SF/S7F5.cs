using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F5 : StreamFuction
    {
        public S7F5()
        {
            this.CODE_NAME = "S7, F5 Process Program Request (PPR)";
            this.DESCRIPTION = "Used by the host to request an existing process program from the equipment.";
        }
    }
}
