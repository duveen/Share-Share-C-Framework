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
            this.STRUCTURE = @"<L[2]
                                    <B[1]> * COMMACK
                                    <L[2]
                                        <A[MAX 6]> * MDLN
                                        <A[MAX 32]> * SOFTREV
                                    >
                                 >";
            this.DetailContents.Add("COMMACK", @"Communications acknowledge code.
0 = Accepted
1 = Denied, try again
2-63 = Reserved");
            this.DetailContents.Add("MDLN", @"Model number; a constant ASCII field. Content is an equipmentspecific
EC.");
            this.DetailContents.Add("SOFTREV", @"The software revision code; a constant ASCII field. Content is
an equipment-specific EC.");
        }
    }
}
