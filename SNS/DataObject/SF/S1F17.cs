using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F17 : StreamFuction
    {
        public S1F17()
        {
            this.CODE_NAME = "S1, F17 Request ON-LINE (RONL)";
            this.DESCRIPTION = "Used by the host to request equipment transition to the ON-LINE control state.";
            this.STRUCTURE = @"Header-only";
        }
    }
}
