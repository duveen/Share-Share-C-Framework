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
            this.STRUCTURE = @"<L[3]
   < U2[1] > *DATAID
   < U2[1] > *CEID
   < L[N]
       < L1[2]
           < U2[1] > *RPTID1
           < L[M]
               < V > *V1
               .
               .
               .
               < V > *VM
           >
       >
       .
     .
       .
       < LN[2]
           < U2[1] > *RPTIDN
           < L[M]
               < V > *V1
               .
               .
               .
               < V > *VM
           >
       >
   >
>";
            this.DetailContents.Add("DATAID", @"Data ID.
In SECS-I environments, the equipment uses the DATAID to
match a multi-block S2F33,F35,F45 with the corresponding
S2F39/40 multi-block inquire/grant. Therefore, the host should
only use a non-zero DATAID when the S2F33,F35,F45
message will be multi-block. If the S2F33,35,45 message is
single-block, the DATAID must be 0.
In HSMS environments, messages are always a single block
and the DATAID must always be 0.");
            this.DetailContents.Add("CEID", @"Collection event ID.");
            this.DetailContents.Add("RPTID", @"Report ID.");
        }
    }
}
