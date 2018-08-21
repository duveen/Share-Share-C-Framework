using System;
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
        }
    }
}
