using System.Text.Json.Serialization;

namespace KeelNotice.Models
{
    public class ServerChanNotice
    {
        [JsonPropertyName("sendkey")]
        public string SendKey { set; get; }
        
        [JsonPropertyName("text")]
        public string Text { set; get; }
        
        [JsonPropertyName("desp")]
        public string Desp { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendkey"></param>
        /// <param name="text"></param>
        /// <param name="desp"></param>
        public ServerChanNotice(string sendkey, string text, string desp)
        {
            SendKey = sendkey;
            Text = text;
            Desp = desp;
        }
    }
}