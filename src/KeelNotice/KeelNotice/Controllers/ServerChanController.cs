
using System.Threading.Tasks;

using KeelNotice.Abstractions;
using KeelNotice.Models;

using Microsoft.AspNetCore.Mvc;

namespace KeelNotice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerChanController : ControllerBase
    {
        private readonly IServerChanWebhook _serverChanWebhook;

        public ServerChanController(IServerChanWebhook serverChanWebhook)
        {
            _serverChanWebhook = serverChanWebhook;
        }

        [HttpPost("Webhook")]
        public async Task Webhook([FromBody] Webhook webhook)
        {
            await _serverChanWebhook.NoticeAsync(webhook);
        }
    }
}