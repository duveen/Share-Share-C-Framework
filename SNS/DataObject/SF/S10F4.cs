using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S10F4 : StreamFuction
    {
        public S10F4()
        {
            this.CODE_NAME = "S10, F4 Terminal Display, Single Acknowledge (VTA)";
            this.DESCRIPTION = "Equipment response to S10,F3";
            this.STRUCTURE = @"<B[1]>. * ACKC10";
            this.DetailContents.Add("ACKC10", @"Stream 10 acknowledge code.
0 = Accepted for display
1 = Message will not be displayed
2 = Terminal not available
3-63 = Reserved");
        }
    }
}
