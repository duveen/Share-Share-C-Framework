using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S1F3 : StreamFuction
    {
        public S1F3()
        {
            this.CODE_NAME = "S1, F3 Selected Equipment Status Request";
            this.DESCRIPTION = "Used to request the values of selected status variables.";
            this.STRUCTURE = @"<L[MAX N]
                                    <U2[1]> * SVID1
                                    .
                                    .
                                    .
                                    <U2[1]> * SVIDN
                                 >";
            this.DetailContents.Add("SVID", @"Status variable ID. Status variables may include any parameter
that can be sampled in time such as temperature or quantity of
a consumable.");
        }
    }
}
