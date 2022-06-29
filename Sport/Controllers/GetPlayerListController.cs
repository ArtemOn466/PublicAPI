using Microsoft.AspNetCore.Mvc;
using Sport.Clients;
using Sport.Models;

namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPlayerListController : ControllerBase
    {
        [HttpGet("PlayerList")]
        public async Task<PlayerList> PlayerList()
        {
            Client client = new Client();
            return client.GetPlayerListAsync().Result;  
        }

        [HttpGet("SavePlayers")]
        public async Task<SavePlayer> SavePlayer(int id)
        {
            Client client = new Client();
            return client.SavePlayer(id).Result;
        }
    }
}
