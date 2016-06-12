using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Input
{
    public class EditChatGroupInfoInput
    {
        public string groupname { get; set; }
        public string description { get; set; }
        public int? maxusers { get; set; }
    }
}
