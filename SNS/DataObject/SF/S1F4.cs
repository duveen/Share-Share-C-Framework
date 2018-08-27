using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F4 : StreamFuction
    {
        public S1F4()
        {
            this.CODE_NAME = "S1, F4 Selected Equipment Status Data (SSD)";
            this.DESCRIPTION = "Returned by the equipment to report the SV values in the order requested.";
            this.STRUCTURE = @"<L[MAX N]
   <V> * SV1
   .
   .
   .
   <V> * SVN
>";
            this.DetailContents.Add("SV", "Status variable value.");
        }
    }
}
