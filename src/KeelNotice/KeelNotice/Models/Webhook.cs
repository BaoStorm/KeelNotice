using System;
using System.Text.Json.Serialization;

namespace KeelNotice.Models
{
    public class Webhook
    {
        [JsonPropertyName("name")]
        public string Name { set; get; }
        
        [JsonPropertyName("message")]
        public string Message { set; get; }
        
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { set; get; } 
        
        [JsonPropertyName("type")]
        public string Type { set; get; }
        
        [JsonPropertyName("level")]
        public string Level { set; get; }

        public string Title()
        {
            return this.Level switch
            {
                "LevelDebug" => "部署前更新",
                "LevelSuccess" => "部署成功",
                "LevelError" => "部署失败",
                _ => "通知"
            };
        }
    }
}