using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S2F36 : StreamFuction
    {
        public S2F36()
        {
            this.CODE_NAME = "S2, F36 Link Event Report Acknowledge (LERA)";
            this.DESCRIPTION = @"Acknowledge or error. If an error condition is detected the entire message is rejected (i.e. partial
                                   changes are not allowed).";
        }
    }
}
