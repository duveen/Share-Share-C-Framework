using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S6F11 : StreamFuction
    {
        public S6F11()
        {
            this.CODE_NAME = "S6,F11 Event Report Send (ERS)";
            this.DESCRIPTION = "Used by the equipment to notify the host of an event.";
        }
    }
}
