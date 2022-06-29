using Microsoft.AspNetCore.Mvc;
using Sport.Clients;
using Sport.Models;

namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetRefereeListController : ControllerBase
    {
        [HttpGet("RefereeList")]
        public async Task<RefereeList> RefereeList()
        {
            Client client = new Client();
            return client.GetRefereeListAsync().Result;
        }

        [HttpGet("SaveReferees")]
        public async Task<SaveReferee> SaveReferee(int id)
        {
            Client client = new Client();
            return client.SaveReferee(id).Result;
        }
    }
}
