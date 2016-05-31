using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK
{
    public class EasemobApiException:Exception
    {
        public EasemobApiException()
        {

        }

        public EasemobApiException(string msg):base(msg)
        {
            
        }

        public EasemobApiException(string msg ,Exception ex):base(msg,ex)
        {

        }
    }
}
