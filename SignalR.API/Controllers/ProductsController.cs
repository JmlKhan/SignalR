using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.API.Hub;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public ProductsController(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
        }

        [HttpPost]
        [Route("productoffers")]
        public string Get()
        {
            List<string> offers = new List<string>();
            offers.Add("20% Off on IPhone 12");
            offers.Add("15% Off on HP Pavillion");
            offers.Add("25% Off on Samsung Smart TV");
            messageHub.Clients.All.SendOffersToUser(offers);
            return "Offers sent successfully to all users!";
        }
    }
}
