using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F18 : StreamFuction
    {
        public S1F18()
        {
            this.CODE_NAME = "S1, F18 ON-LINE Acknowledge (ONLA)";
            this.DESCRIPTION = "ON-LINE request acknowledge or error.";
            this.STRUCTURE = @"<B[1]>. * ONLACK";
            this.DetailContents.Add("ONLACK", @"ON-LINE request acknowledge code.
0 = ON - LINE accepted
1 = ON - LINE not allowed
2 = Equipment already ON - LINE
3 - 63 = Reserved");
        }
    }
}
