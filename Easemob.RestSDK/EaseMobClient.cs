﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Easemob.RestSDK.Dto.Input;
using Easemob.RestSDK.Dto.Output;

namespace Easemob.RestSDK
{
   public class EaseMobClient
    {
        string reqUrlFormat = "https://a1.easemob.com/{0}/{1}/";
        public string clientID { get; set; }
        public string clientSecret { get; set; }
        public string appName { get; set; }
        public string orgName { get; set; }
        public string token { get; set; }
        public string easeMobUrl { get { return string.Format(reqUrlFormat, orgName, appName); } }

        public RestClient client { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="easeAppClientID">client_id</param>
        /// <param name="easeAppClientSecret">client_secret</param>
        /// <param name="easeAppName">应用标识之应用名称</param>
        /// <param name="easeAppOrgName">应用标识之登录账号</param>
        public  EaseMobClient(string easeAppClientID, string easeAppClientSecret, string easeAppName, string easeAppOrgName)
        {
            this.clientID = easeAppClientID;
            this.clientSecret = easeAppClientSecret;
            this.appName = easeAppName;
            this.orgName = easeAppOrgName;           
            this.client = new RestClient(easeMobUrl);
            
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {                    
           
            var response =await client.ExecuteTaskAsync<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
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
                      
            RestRequest req = new RestRequest("token", Method.POST);
            req.AddJsonBody(new LoginModel() { client_id = clientID, client_secret = clientSecret, grant_type = "client_credentials" });
            var re=await ExecuteAsync<LoginOutput>(req);
            return re;
        }
    }
}
