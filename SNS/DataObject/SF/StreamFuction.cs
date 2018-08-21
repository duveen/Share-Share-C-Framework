using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{

    [DataContract]
    #region [ KnoewType ]    
    [KnownType(typeof(S1F3))]
    [KnownType(typeof(S1F4))]
    [KnownType(typeof(S1F13))]
    [KnownType(typeof(S1F14))]
    [KnownType(typeof(S1F17))]
    [KnownType(typeof(S1F18))]

    [KnownType(typeof(S2F33))]
    [KnownType(typeof(S2F34))]
    [KnownType(typeof(S2F35))]
    [KnownType(typeof(S2F36))]
    [KnownType(typeof(S2F37))]
    [KnownType(typeof(S2F38))]
    [KnownType(typeof(S2F41))]
    [KnownType(typeof(S2F42))]

    [KnownType(typeof(S5F1))]

    [KnownType(typeof(S6F11))]

    [KnownType(typeof(S7F1))]
    [KnownType(typeof(S7F2))]
    [KnownType(typeof(S7F3))]
    [KnownType(typeof(S7F4))]
    [KnownType(typeof(S7F5))]
    [KnownType(typeof(S7F6))]

    [KnownType(typeof(S10F3))]
    [KnownType(typeof(S10F4))]
    #endregion
    public class StreamFuction
    {
        [DataMember]
        public string CODE_NAME { get; set; } = string.Empty;
        [DataMember]
        public string DESCRIPTION { get; set; } = string.Empty;
        [DataMember]
        public string STRUCTURE { get; set; } = string.Empty;
    }
}
