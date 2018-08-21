using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F41 : StreamFuction
    {
        public S2F41()
        {
            this.CODE_NAME = "S2, F41 Host Command Send (HCS)";
            this.DESCRIPTION = "The host requests the equipment perform a specified remote command.";
        }
    }
}
