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
            this.STRUCTURE = @"<B[1]>. * ACKC7";
            this.DetailContents.Add("ACKC7", @"Stream 7 acknowledge code.
0 = Accepted
1 = Permission not granted (busy)
2 = Length error
4 = PPID not found
5 = Mode unsupported (equipment not under
 remote control)
6-63 = Reserved");        
        }
    }
}
