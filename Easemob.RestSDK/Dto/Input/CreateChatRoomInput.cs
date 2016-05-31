using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Input
{
 

    public class CreateChatRoomInput
    {
        public string name { get; set; }
        public string description { get; set; }
        public int maxusers { get; set; }
        public string owner { get; set; }
        public string[] members { get; set; }
    }

}
