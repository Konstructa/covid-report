using Newtonsoft.Json;

namespace CovidReport.DTO
{
    public class GetServer
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("server")]
        public string Server { get; set; }
    }

}
