using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]    
    public class S10F3 : StreamFuction
    {
        public S10F3()
        {
            this.CODE_NAME = "S10, F3 Terminal Display, Single (VTN)";
            this.DESCRIPTION = "The host requests the equipment to display a single line of text on its terminal display";
        }
    }
}
