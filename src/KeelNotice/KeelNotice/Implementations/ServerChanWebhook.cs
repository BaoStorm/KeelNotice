using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using KeelNotice.Abstractions;
using KeelNotice.Models;
using KeelNotice.RestfulApi;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KeelNotice.Implementations
{
    public class ServerChanServerChanWebhook : IServerChanWebhook
    {
        private readonly IConfiguration _configuration;
        private readonly BaseRestfulApi _baseRestfulApi;
        private readonly IOptionsSnapshot<ServerChanOptions> _serverChanOptions;

        public ServerChanServerChanWebhook(IConfiguration configuration, BaseRestfulApi baseRestfulApi, IOptionsSnapshot<ServerChanOptions> serverChanOptions)
        {
            _configuration = configuration;
            _baseRestfulApi = baseRestfulApi;
            _serverChanOptions = serverChanOptions;
        }

        public async Task NoticeAsync(Webhook webhook)
        {
            var tasks  = _serverChanOptions.Value.ScKeys.Select(key =>
            {
                var desp = @$"
#### 消息  
{webhook.Message}
#### 时间  
`{webhook.CreatedAt:yyyy-MM-dd HH:mm:ss fff}`";
                var hostApi = string.Format(_serverChanOptions.Value.Api, key);
                var url = $"{hostApi}?text={webhook.Title()}&desp={WebUtility.UrlEncode(desp)}";
                return _baseRestfulApi.GetStringAsync(url);
            }).ToList();
            
            await Task.WhenAll(tasks);
        }
    }
}