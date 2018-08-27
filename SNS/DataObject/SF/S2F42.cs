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
        public Dictionary<string, string> DetailContents = new Dictionary<string, string>();
        public S2F42()
        {
            this.CODE_NAME = "S2,F42 Host Command Acknowledge (HCA)";
            this.DESCRIPTION = "Host command acknowledge or error.";
            this.STRUCTURE = @"<L[2]
                                    <B[1]> * HCACK
                                    <L[1] **
                                        <L[2]
                                            <A[MAX N ]> * CPNAME
                                            <V> * CPACK
                                        >
                                    >
                                 >";
            this.DetailContents.Add("HCACK", @"Host command parameter acknowledge code.
0 = Acknowledge; command has been performed
1 = Command does not exist
2 = Cannot perform now
3 = At least one parameter is invalid
4 = Acknowledge; command will be performed
5 = Rejected; already in desired condition
6 = Unable to perform, Internal error occurred.
7-63 = Reserved");
            this.DetailContents.Add("CPNAME", @"Command parameter name.");
            this.DetailContents.Add("CPACK", @"Command parameter acknowledge code.
1 = Parameter name does not exist
2 = Illegal value specified
3 = Illegal format specified for CPVAL
4-63 = Reserved");

        }
    }
}
