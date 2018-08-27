using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S7F1 : StreamFuction
    {
        public S7F1()
        {
            this.CODE_NAME = "S7, F1 Process Program Load Inquire (PPI) ";
            this.DESCRIPTION = @"This message is used by the host to inquire whether or not the equipment will accept the download
                                   of a multi - block process program.";
            this.STRUCTURE = @"<L[2]
                                    <A[MAX 80]> * PPID
                                    <U4[1]> * LENGTH
                                 >";
            this.DetailContents.Add("PPID", @"Process program ID. This is the name of the process program:
If PPSelectMode = 0, use standard DOS compatible “8.3”
format.
If PPSelectMode = 1, use 80 characters maximum.
The host system must first determine the process program select mode of the equipment by requesting the PPSelectMode
status variable (SVID3106). Currently, the process program
select mode can only be set manually at the equipment.");
            this.DetailContents.Add("LENGTH", @"Process program body (PPBODY) length, in bytes.");
        }
    }
}
