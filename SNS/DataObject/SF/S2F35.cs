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
        }
    }
}
