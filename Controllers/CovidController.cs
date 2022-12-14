using System.IO;
using CovidReport.DTO;
using CovidReport.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CovidReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ILogger<CovidController> _logger;
        private readonly IConfiguration _config;

        public CovidController(ILogger<CovidController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet(Name = "GetCovidAll")]
        public async Task<CovidAll> Get()
        {
            var url = "https://disease.sh/v3/covid-19/all";

            var requisicao = new HttpClient();

            var stringTask = await requisicao.GetAsync(url);

            var jsonResponse = await stringTask.Content.ReadAsStringAsync();

            CovidAll covid = JsonConvert.DeserializeObject<CovidAll>(jsonResponse);

            var file = FileService.CreateFile(covid);

            await new SendService().SendFormData(_config, file);

            return covid;
        }

    }
}
