using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F38 : StreamFuction
    {
        [DataMember]
        public string CODE_NAME { get; set; } = "S2F38";
    }
}
