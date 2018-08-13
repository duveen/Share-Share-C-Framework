using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F42 : StreamFuction
    {
        public S2F42()
        {
            this.CODE_NAME = "S2F42";
        }
    }
}
