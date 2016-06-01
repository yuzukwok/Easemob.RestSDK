using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Easemob.RestSDK
{
    public class JsonNetDeserializer : IDeserializer
    {
      
        public string DateFormat
        {
            get;set;
        }

        public string Namespace
        {
            get;set;
        }

        public string RootElement
        {
            get;set;
        }

        public T Deserialize<T>(IRestResponse response)
        {
           return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
