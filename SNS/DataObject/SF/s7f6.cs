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
            this.STRUCTURE = @"<L[2]
   <A[MAX 80]> * PPID
   <B[MAX N]> * PPBODY
>";
            this.DetailContents.Add("PPID", @"Process program ID. This is the name of the process program:
If PPSelectMode = 0, use standard DOS compatible “8.3”
format.
If PPSelectMode = 1, use 80 characters maximum.
The host system must first determine the process program select mode of the equipment by requesting the PPSelectMode
status variable (SVID3106). Currently, the process program select mode can only be set manually at the equipment.");
            this.DetailContents.Add("PPBODY", @"Process program body. Maximum N (approximate) = 232
(HSMS) or 7.9Mb (SECS-I).");
        }
    }
}
