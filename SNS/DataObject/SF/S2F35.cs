using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F35 : StreamFuction
    {
        public S2F35()
        {
            this.CODE_NAME = "S2, F35 Link Event Report (LER)";
            this.DESCRIPTION = @"Used by the host to associate reports with specific collection events on the equipment. Association
                                   is performed by grouping host-defined RPTIDs with equipment-defined CEIDs. A report must be
                                   defined before it is linked to an event (see S2,F33). In SECS-I environments, if this message is
                                   multi-block, then it must be preceded by a successful S2,F39/S2,F40 Inquire/Grant transaction.";
            this.STRUCTURE = @"<L[2]
   <U2[1]> * DATAID ()
   <L[N]
       <L1[2]
           <U2[1]> * CEID1
           <L[M]
               <U2[1]>* RPTID1
               .
               .
               .
               <U2[1]>* RPTIDM
           >
       >                                        
       .
       .
       .
       <LN[2]
           <U2[1]> * CEIDN
           <L[M]
           <U2[1]>* RPTID1
           .
           .
           .
           <U2[1]>* RPTIDM
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
            this.DetailContents.Add("RPTID", @"ReportID.");            
        }
    }
}
