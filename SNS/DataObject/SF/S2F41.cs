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
            this.STRUCTURE = @"<L[2]
                                    <A[MAX 20]> * RCMD
                                    <L[MAX 1]
                                        <L[2]
                                            <A[MAX N]> * CPNAME
                                            <V> * CPVAL
                                        >
                                    >
                                >";
            this.DetailContents.Add("RCMD", @"Remote command code. Case is not significant and dashes ‘-‘
may be substituted for underscores ‘_’. See section 4.6 for
more information regarding remote commands.");
            this.DetailContents.Add("CPNAME", @"Command parameter name.");
            this.DetailContents.Add("CPVAL", @"Command parameter value.");
        }
    }
}
