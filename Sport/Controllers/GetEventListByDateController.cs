using Microsoft.AspNetCore.Mvc;
using Sport.Clients;
using Sport.Models;


namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetEventListByDateController : ControllerBase
    {

        [HttpGet("EventListByDate")]

        public async Task<EventListByDate> EventListByDate(string date) 
        {
            Client client = new Client();
            return client.GetEventListByDateAsync(date).Result;
        }
    }
}
