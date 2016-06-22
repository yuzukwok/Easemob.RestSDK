using Newtonsoft.Json.Linq;
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
        public IDictionary<string, string> data { get; set; }
    }

    public class EaseApiResultGroupInfoData : EaseApiResult
    {
        public IList<GroupInfo> data { get; set; }
    }

    public class GroupInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool @public { get; set; }
        public bool membersonly { get; set; }
        public bool allowinvites { get; set; }
        public int maxusers { get; set; }
        public int affiliations_count { get; set; }
        public Affiliation[] affiliations { get; set; }
    }

    public class Affiliation
    {
        public string owner { get; set; }
        public string member { get; set; }
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

    public class EaseApiResultChatData
    {
        public string action { get; set; }
        public string application { get; set; }
        public Params _params { get; set; }
        public string path { get; set; }
        public string uri { get; set; }
        public ChatEntity[] entities { get; set; }
        public long timestamp { get; set; }
        public int duration { get; set; }
        public string organization { get; set; }
        public string applicationName { get; set; }
        public string cursor { get; set; }
        public int count { get; set; }
    }
    public class ChatEntity
    {
        public string uuid { get; set; }
        public string type { get; set; }
        public string from { get; set; }
        public long created { get; set; }
        public long modified { get; set; }
        public string username { get; set; }
        public string msg_id { get; set; }
        public string to { get; set; }
        public string chat_type { get; set; }
        public string groupid { get; set; }
        public Chatpayload payload { get; set; }
        public long timestamp { get; set; }
    }

    public class Chatpayload
    {
        public ChatMsg[] bodies { get; set; }
        public IDictionary<string, object> ext { get; set; }
    }

    public class ChatMsg
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// txt img loc audio四类
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 语音时长
        /// </summary>
        public int length { get; set; }
        public string url { get; set; }
        public string secret { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string addr { get; set; }
        public string filename { get; set; }

    }
}
