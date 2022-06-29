using Microsoft.AspNetCore.Mvc;
using Sport.Clients;
using Sport.Models;


namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetEventLiveListController : ControllerBase
    {
        [HttpGet("EventLiveList")]
        public async Task<EventLiveList> EventLiveList()
        {
            Client client = new Client();
            return client.GetEventLiveListAsync().Result;
        }

    }
}
