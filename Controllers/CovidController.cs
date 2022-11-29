
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CovidReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ILogger<CovidController> _logger;

        public CovidController(ILogger<CovidController> logger)
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
