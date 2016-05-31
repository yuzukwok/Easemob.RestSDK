using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Output
{
    public class ErrorOutput
    {
        public string error { get; set; }
        public long timestamp { get; set; }
        public int duration { get; set; }
        public string exception { get; set; }
        public string error_description { get; set; }
    }




}
