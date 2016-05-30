using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Output
{
  

    public class LoginOutput
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string application { get; set; }
    }

}
