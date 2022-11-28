using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetCovidAll")]
        public async Task<CovidAll> Get()
        {
            var url = "https://disease.sh/v3/covid-19/all"; 

            var requisicao = new HttpClient();

            var stringTask = await requisicao.GetAsync(url);

            var jsonResponse = await stringTask.Content.ReadAsStringAsync();

            CovidAll covid = JsonConvert.DeserializeObject<CovidAll>(jsonResponse);
           
            return covid;

        }
    }
}