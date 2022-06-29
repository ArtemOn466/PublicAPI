using Microsoft.AspNetCore.Mvc;
using Sport.Clients;
using Microsoft.Extensions.Logging;

namespace Sport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly ILogger<WeatherForecastController> _logger;
        //private readonly Client client1;
        

        //public WeatherForecastController(ILogger<WeatherForecastController> logger, Client client)
        //{
        //    client1 = client;
        //    _logger = logger;
           
        //}

        //[HttpGet]
        //public async Task<GetItemResponse> GetDataFromDb()
        //{

        //    var table = "kursova";
        //    var item = new GetItemRequest
        //    {
        //        TableName = table,
        //        Key = new Dictionary<string, AttributeValue>
        //        {
        //            {"id", new AttributeValue{ S = "1"} }
        //        }
        //    };

        //    var response = await _dynamoDb.GetItemAsync(item);
        //    //if (response = null || !response.IsItemSet)
        //    //{
        //    //    return null;
        //    //}
        //    return response;
        //}



    }
}