using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F36 : StreamFuction
    {
        public S2F36()
        {
            this.CODE_NAME = "S2, F36 Link Event Report Acknowledge (LERA)";
            this.DESCRIPTION = @"Acknowledge or error. If an error condition is detected the entire message is rejected (i.e. partial
                                   changes are not allowed).";
            this.STRUCTURE = @"<B[1]> * LRACK";
            this.DetailContents.Add("LRACK ", @"Link report acknowledge code.
0 = Accepted
1 = Denied. Insufficient space
2 = Denied. Invalid format
3 = Denied. At least one CEID link already defined
4 = Denied. At least one CEID does not exist
5 = Denied. At least one RPTID does not exist
6 = Denied. Invalid DATAID or internal runtime error
7-63 = Reserved");
        }
    }
}
