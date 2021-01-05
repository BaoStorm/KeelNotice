using System.Threading.Tasks;

using KeelNotice.Models;

namespace KeelNotice.Abstractions
{
    public interface IServerChanWebhook
    {
        Task NoticeAsync(Webhook webhook);
    }
}