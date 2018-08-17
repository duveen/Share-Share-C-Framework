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
        }
    }
}
