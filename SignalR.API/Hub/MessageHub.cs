using Microsoft.AspNetCore.SignalR;

namespace SignalR.API.Hub
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public async Task SendOfferToUsers(List<string> message)
        {
            await Clients.All.SendOffersToUser(message);
        }
    }
}
