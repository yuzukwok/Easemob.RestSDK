using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Output
{
 
    public class CreateChatRoomOutput
    {
        public string action { get; set; }
        public string application { get; set; }
        public string uri { get; set; }
        public object[] entities { get; set; }
        public Data data { get; set; }
        public long timestamp { get; set; }
        public int duration { get; set; }
        public string organization { get; set; }
        public string applicationName { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
    }

}
