using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F2 : StreamFuction
    {
        public S7F2()
        {
            this.CODE_NAME = "S7, F2 Process Program Load Grant (PPG)";
            this.DESCRIPTION = @"Equipment reply to host-originated S7,F1. Used to acknowledge or reject host request to download
                                   multi-block process program.";
            this.STRUCTURE = @"<B[1]> * PPGNT";
            this.DetailContents.Add("PPGNT", @"Process program grant status.
0 = OK
1 = Already have
2 = No space
3 = Invalid PPID
4 = Busy, try later
5 = Will not accept
6-63 = Reserved");
        }
    }
}
