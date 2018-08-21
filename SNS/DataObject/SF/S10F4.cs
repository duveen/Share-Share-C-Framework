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
        }
    }
}
