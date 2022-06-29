using Microsoft.AspNetCore.Mvc;
using Sport.Models;
using Sport.Clients;

namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTeamListControleer : ControllerBase
    {
        [HttpGet("TeamList")]
        public async Task<TeamList> TeamList()
        {
            Client client = new Client();
            return client.GetTeamListAsync().Result;
        }
    }
}
