using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Output
{

    public class EaseApiResultData : EaseApiResult
    {
        public string[] data { get; set; }
    }
    public class EaseApiResultKvData : EaseApiResult
    {
        public IDictionary<string,string> data { get; set; }
    }
    public class EaseApiResult
    {
        public string action { get; set; }
        public string application { get; set; }
        public Params _params { get; set; }
        public string path { get; set; }
        public string uri { get; set; }
        public Entity[] entities { get; set; }
        public long timestamp { get; set; }
        public int duration { get; set; }
        public string organization { get; set; }
        public string applicationName { get; set; }
        public string cursor { get; set; }
        public int count { get; set; }
    }

    public class Params
    {
        string[] limit;
    }

    public class Entity
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public long created { get; set; }
        public long modified { get; set; }
        public string username { get; set; }
        public bool activated { get; set; }
        public string device_token { get; set; }
        public string nickname { get; set; }
    }


}
