using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easemob.RestSDK.Dto.Input
{
   

    public class EaseMsg<T> where T:Msg
    {
        /// <summary>
        /// 类型 users 用户，chatgroups 群聊 chatrooms 聊天室
        /// </summary>
        public string target_type { get; set; }
        /// <summary>
        /// 发送对象 对方用户名
        /// </summary>
        public string[] target { get; set; }
        public T msg { get; set; }
        /// <summary>
        /// 发送者
        /// </summary>
        public string from { get; set; }
    }
    public class Msg
    {
        public string type { get; internal set; }
        public IDictionary<string, string> ext { get; set; }
    }
    public class TextMsg:Msg
    {
        public TextMsg()
        {
            type = "txt";
        }
       
        public string msg { get; set; }
    }
    public class ImgMsg:Msg
    {
        public ImgMsg()
        {
            type = "img";
        }

        public string url { get; set; }
        public string filename { get; set; }
        public string secret { get; set; }
        public ImgSize size { get; set; }
    }
    public class AudioMsg : Msg
    {
        public AudioMsg()
        {
            type = "audio";
        }

        public string url { get; set; }
        public string filename { get; set; }
        public string secret { get; set; }
        public int length { get; set; }
    }

    public class VideoMsg : Msg
    {
        public VideoMsg()
        {
            type = "video";
        }

        public string url { get; set; }
        public string filename { get; set; }
        public string secret { get; set; }
        public string thumb { get; set; }
        public int length { get; set; }
        public int file_length { get; set; }
        public string thumb_secret { get; set; }
    }
    public class ActionMsg:Msg {
        public ActionMsg()
        {
            type = "cmd";
        }
        public string action { get; set; }
    }
    public class ImgSize
    {
        public int width { get; set; }
        public int height { get; set; }
    }

}
