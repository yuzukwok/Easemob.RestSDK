using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Easemob.RestSDK.Dto.Input;
using Easemob.RestSDK.Dto.Output;
using System.Runtime.Caching;
using Easemob.RestSDK.Interface;
using Newtonsoft.Json;

namespace Easemob.RestSDK
{
    public class EaseMobClient : IEaseMobApi
    {
        string reqUrlFormat = "https://a1.easemob.com/{0}/{1}/";
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string appName { get; set; }
        public string orgName { get; set; }
        public string token { get; set; }
        public string easeMobUrl { get { return string.Format(reqUrlFormat, orgName, appName); } }

        MemoryCache cache = new MemoryCache("EaseMob");

        public RestClient client { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="easeAppClientID">client_id</param>
        /// <param name="easeAppClientSecret">client_secret</param>
        /// <param name="easeAppName">应用标识之应用名称</param>
        /// <param name="easeAppOrgName">应用标识之登录账号</param>
        public EaseMobClient(string easeAppClientID, string easeAppClientSecret, string easeAppName, string easeAppOrgName)
        {
            this.clientID = easeAppClientID;
            this.clientSecret = easeAppClientSecret;
            this.appName = easeAppName;
            this.orgName = easeAppOrgName;
            this.client = new RestClient(easeMobUrl);
            //this.client.RemoveHandler("application/json");
            this.client.ClearHandlers();
            this.client.AddHandler("application/json", new JsonNetDeserializer());


        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var token = await QueryToken();
            request.AddHeader("Authorization", "Bearer " + token);
            
            var response = await client.ExecuteTaskAsync<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new EasemobApiException(message, response.ErrorException);
                throw twilioException;
            }
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest|| response.StatusCode== System.Net.HttpStatusCode.NotFound||response.StatusCode== System.Net.HttpStatusCode.InternalServerError)
            {
                var error = JsonConvert.DeserializeObject<ErrorOutput>(response.Content);
                var twilioException = new EasemobApiException(error.error + "|" + error.error_description);
                throw twilioException;
            }

            return response.Data;
        }

        /// <summary>
        /// 使用app的client_id 和 client_secret登陆并获取授权token
        /// </summary>
        /// <returns></returns>
        async Task<string> QueryToken()
        {
            if (string.IsNullOrEmpty(clientID) || string.IsNullOrEmpty(clientSecret)) { return string.Empty; }
            //read cache

            if (!cache.Contains("token"))
            {
                RestRequest req = new RestRequest("token", Method.POST);
                req.AddJsonBody(new LoginModel() { client_id = clientID, client_secret = clientSecret, grant_type = "client_credentials" });

                var re = await client.ExecuteTaskAsync<LoginOutput>(req).ConfigureAwait(false);
                if (re.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    var twilioException = new ApplicationException(message, re.ErrorException);
                    throw twilioException;
                }
                //add cache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddDays(6);
                cache.Add(new CacheItem("token", re.Data.access_token), policy);

            }
            var retoken = cache.Get("token");
            return retoken.ToString();
        }

        public async Task<EaseApiResult> CreateUserBatch(IList<UserReg> input)
        {
            var req = new RestRequest("users", Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> CreateUser(UserReg input)
        {
            var req = new RestRequest("users", Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<CreateChatRoomOutput> CreateChatRoom(CreateChatRoomInput input)
        {
            var req = new RestRequest("chatrooms", Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<CreateChatRoomOutput>(req);
        }

        public async Task<EaseApiResult> ChangeUserNickname(string username, ChangeIMUserNicknameInput input)
        {
            var req = new RestRequest("users/" + username, Method.PUT);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> GetUser(string username)
        {
            var req = new RestRequest("users/" + username, Method.GET);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> GetUserList(string username,string cursor="", int limit = 10)
        {
            var req = new RestRequest("users", Method.GET);
            req.AddQueryParameter("limit", limit.ToString());
            if (!string.IsNullOrEmpty(cursor))
            {
                req.AddQueryParameter("cursor", cursor);
            }
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> DelUser(string username)
        {
            var req = new RestRequest("users/" + username, Method.DELETE);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> DelUserBatch(int limit)
        {
            var req = new RestRequest("users", Method.DELETE);
            req.AddQueryParameter("limit", limit.ToString());
          
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> ChangeUserPassword(string username, ChangeUserPasswordInput input)
        {
            var req = new RestRequest("users/" + username+"/password", Method.PUT);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> AddBuddy(string ownerusername, string friendusername)
        {
            var req = new RestRequest("users/" + ownerusername + "/contacts/users/"+friendusername, Method.PUT);
            return await ExecuteAsync<EaseApiResult>(req);
        }
        public async Task<EaseApiResult> DelBuddy(string ownerusername, string friendusername)
        {
            var req = new RestRequest("users/" + ownerusername + "/contacts/users/" + friendusername, Method.DELETE);
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResultData> GetBuddys(string ownerusename)
        {
            var req = new RestRequest("users/" + ownerusename + "/contacts/users", Method.GET);
            return await ExecuteAsync<EaseApiResultData>(req);
        }

        public async Task<EaseApiResultData> GetBuddyInBlackList(string ownerusename)
        {
            var req = new RestRequest("users/" + ownerusename + "/blocks/users", Method.GET);
            return await ExecuteAsync<EaseApiResultData>(req);
        }

        public async Task<EaseApiResultData> AddBuddyInBlackList(string ownerusername, AddBuddyInBlackListInput input)
        {
            var req = new RestRequest("users/" + ownerusername + "/blocks/users", Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResultData>(req);
        }

        public async Task<EaseApiResult> DelBuddyInBlackList(string ownerusername, string username)
        {
            var req = new RestRequest("users/" + ownerusername + "/blocks/users/"+username, Method.DELETE);
        
            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResultKvData> CheckUserStatus(string username)
        {
            var req = new RestRequest("users/" + username + "/status", Method.GET);

            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> CheckUserOfflineMsgCount(string username)
        {
            var req = new RestRequest("users/" + username + "/offline_msg_count", Method.GET);

            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> CheckUserOfflineMsgStatus(string username, string msgid)
        {
            var req = new RestRequest("users/" + username + "/offline_msg_status/"+msgid, Method.POST);

            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResult> DeactivateUser(string username)
        {
            var req = new RestRequest("users/" + username + "/deactivate", Method.POST);

            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResult> ActivateUser(string username)
        {
            var req = new RestRequest("users/" + username + "/activate", Method.POST);

            return await ExecuteAsync<EaseApiResult>(req);
        }

        public async Task<EaseApiResultKvData> DisconnectUser(string username)
        {
            var req = new RestRequest("users/" + username + "/disconnect", Method.GET);

            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> CreateChatGroup(CreateChatGroupInput input)
        {
            var req = new RestRequest("chatgroups" , Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultChatData> GetChatMessages(string ql,string cursor, int limit = 10)
        {
            var req = new RestRequest("chatmessages", Method.GET);
            if (!string.IsNullOrEmpty(ql))
            {
                //空格替换成+
                ql = ql.Replace(" ", "+");
                req.AddQueryParameter("ql", ql);
            }

            req.AddQueryParameter("limit", limit.ToString());
            if (!string.IsNullOrEmpty(cursor))
            {
                req.AddQueryParameter("cursor", cursor);
            }
            return await ExecuteAsync<EaseApiResultChatData>(req);
        }

        public async Task<EaseApiResultKvData> CreateChatGroupUser(string groupid, string username)
        {
            var req = new RestRequest("chatgroups/"+groupid+"/users/"+username, Method.POST);
          
            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> CreateChatGroupUserBatch(string groupid, CreateChatGroupUserInput input)
        {
            var req = new RestRequest("chatgroups/" + groupid + "/users", Method.POST);
            req.AddJsonBody(input);
            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> DelChatGroupUser(string groupid, string username)
        {
            var req = new RestRequest("chatgroups/" + groupid + "/users/"+username, Method.DELETE);
            
            return await ExecuteAsync<EaseApiResultKvData>(req);
        }

        public async Task<EaseApiResultKvData> DelChatGroupUserBatch(string groupid, string[] usernames)
        {
            var req = new RestRequest("chatgroups/" + groupid + "/users/" + string.Join(",",usernames), Method.DELETE);

            return await ExecuteAsync<EaseApiResultKvData>(req);
        }
    }
}
