using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F34 : StreamFuction
    {
        public S2F34()
        {
            this.CODE_NAME = "S2, F34 Define Report Acknowledge (DRA)";
            this.DESCRIPTION = @"Acknowledge or error. If an error condition is detected the entire message is rejected (i.e. partial
                                   changes are not allowed).";
            this.STRUCTURE = @"<B[1]>. * DRACK";
            this.DetailContents.Add("DRACK", @"Define report acknowledge code.
0 = Accepted
1 = Denied. Insufficient space
2 = Denied. Invalid format
3 = Denied. At least one RPTID already defined
4 = Denied. At least one VID does not exist
5 = DATAID Not found or other internal error
6-63 = Reserved");
        }
    }
}
