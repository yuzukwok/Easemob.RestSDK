using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Input
{

    public class CreateChatGroupInput
    {
        public string groupname { get; set; }
        public string desc { get; set; }
        public bool @public { get; set; }
        public int maxusers { get; set; }
        public bool approval { get; set; }
        public string owner { get; set; }
        public string[] members { get; set; }
    }

}
