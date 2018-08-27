using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNS.DataObject.SF
{
    [DataContract]
    public class S5F1 : StreamFuction
    {
        public S5F1()
        {
            this.CODE_NAME = "S5, F1 Alarm Report Send (ARS)";
            this.DESCRIPTION = "Report change in or presence of an alarm condition.";
            this.STRUCTURE = @"<L[3]
    <B[1]> * ALCD
    <U2[1]> * ALID
    <A[MAX 40]> * ALTX
 >";
            this.DetailContents.Add("ALCD", @"Alarm code.
bit 8 = 1 means alarm set
bit 8 = 0 means alarm cleared
bits 7 - 1 is alarm category code:
0 = Not used
1 = Personal safety
2 = Equipment safety
3 = control warning
4 = Parameter control error
5 = Irrecoverable error
6 = Equipment status warning
7 = Attention flags
8 = Data integrity
>8 = Other categories
9-63 = Reserved");
            this.DetailContents.Add("ALID", @"Alarm identification.");
            this.DetailContents.Add("ALTX", @"Alarm text, limited to 40 characters.");
        }
    }
}
