using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F3 : StreamFuction
    {
        public S7F3()
        {
            this.CODE_NAME = "S7F3";
        }
    }
}
