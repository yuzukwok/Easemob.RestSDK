using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Output
{


    public class RegisterIMUsersOutput
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
    }

    public class Params
    {
    }

    public class Entity
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public long created { get; set; }
        public long modified { get; set; }
        public string username { get; set; }
        public bool activated { get; set; }
    }


}
