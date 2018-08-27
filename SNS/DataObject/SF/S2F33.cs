using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F33 : StreamFuction
    {
        public S2F33()
        {
            this.CODE_NAME = "S2, F33 Define Report (DR)";
            this.DESCRIPTION = @"Used by the host to associate equipment variables with discrete reports to be provided with
                                   collection events. Association is performed by grouping specific equipment - defined VIDs with hostdefined      
                                   RPTIDs.
                                   In SECS-I environments, if this message is multi - block, then it must be preceded by a successful
                                   S2,F39 / S2,F40 Inquire/ Grant transaction.";
            this.STRUCTURE = @"<L[2]
                                    <U2[1]> * DATAID
                                    <L[N]
                                        <L1[2]
                                            <U2[1]> * RPTID1
                                            <L[M]
                                                <U2[1]>* SVID1
                                                .
                                                .
                                                .
                                                <U2[1]>* SVIDM
                                            >
                                        >
                                        .
                                        .
                                        .
                                            <LN[2]
                                                <U2[1]> * RPTIDN
                                                <L[M]
                                                    <U2[1]>* SVID1
                                                    .
                                                    .
                                                    .
                                                    <U2[1]>* SVIDM
                                                >
                                            >
                                        >
                                    >                                >";
            this.DetailContents.Add("DATAID", @"Data ID.
In SECS - I environments, the equipment uses the DATAID to
match a multi - block S2F33, F35, F45 with the corresponding
S2F39 / 40 multi - block inquire / grant.Therefore, the host should
only use a non - zero DATAID when the S2F33, F35, F45
message will be multi - block.If the S2F33, 35, 45 message is
single - block, the DATAID must be 0.
In HSMS environments, messages are always a single block
and the DATAID must always be 0.");
            this.DetailContents.Add("RPTID ", @"ReportID");
            this.DetailContents.Add("SVID ", @"Status variable ID. Status variables may include any parameter
that can be sampled in time such as temperature or quantity of
a consumable.");
        }
    }
}
