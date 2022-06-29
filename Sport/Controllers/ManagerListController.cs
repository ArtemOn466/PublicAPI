using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sport.Clients;
using Sport.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerListController : ControllerBase
    {
        [HttpGet("ManagerList")]
        public async Task<ManagerList> ManagerList()
        {
            Client client = new Client();
            return client.GetManagerListAsync().Result; 
        }

        [HttpGet("SaveManagers")]
        public async Task<SaveManager> SaveManager(int id)
        {   
            Client client1 = new Client();
            return client1.SaveManager(id).Result;
        }
    }
}
        
        
    
 

        

