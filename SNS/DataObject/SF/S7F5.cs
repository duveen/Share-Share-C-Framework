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
            this.STRUCTURE = @"<A[MAX 80]>. * PPID";
            this.DetailContents.Add("PPID", @"Process program ID. This is the name of the process program:
If PPSelectMode = 0, use standard DOS compatible “8.3”
format.
If PPSelectMode = 1, use 80 characters maximum.
The host system must first determine the process program select mode of the equipment by requesting the PPSelectMode
status variable (SVID3106). Currently, the process program select mode can only be set manually at the equipment.");
        }
    }
}
