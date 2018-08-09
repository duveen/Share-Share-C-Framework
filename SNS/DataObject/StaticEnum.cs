using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject
{

    [DataContract]
    public enum HIGH_RANK_DIVISION
    {
        [EnumMember]
        WARN,
        [EnumMember]
        INFO,
        [EnumMember]
        SEND,
        [EnumMember]
        RECV,
        [EnumMember]
        NON
    };
    
}
