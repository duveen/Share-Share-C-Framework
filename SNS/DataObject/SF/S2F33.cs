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
        }
    }
}
