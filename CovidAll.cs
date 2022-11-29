using Newtonsoft.Json;

namespace CovidReport
{
    public class CovidAll
    {

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("cases")]
        public long Cases { get; set; }

        [JsonProperty("todayCases")]
        public long TodayCases { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; set; }

        [JsonProperty("recovered")]
        public long Recovered { get; set; }

        [JsonProperty("todayRecovered")]
        public int TodayRecovered { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("critical")]
        public int Critical { get; set; }

        [JsonProperty("casesPerOneMillion")]
        public int CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")]
        public double DeathsPerOneMillion { get; set; }

        [JsonProperty("tests")]
        public long Tests { get; set; }

        [JsonProperty("testsPerOneMillion")]
        public double TestsPerOneMillion { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("oneCasePerPeople")]
        public int? OneCasePerPeople { get; set; }

        [JsonProperty("oneDeathPerPeople")]
        public int? OneDeathPerPeople { get; set; }

        [JsonProperty("oneTestPerPeople")]
        public int? OneTestPerPeople { get; set; }

        [JsonProperty("activePerOneMillion")]
        public double ActivePerOneMillion { get; set; }

        [JsonProperty("recoveredPerOneMillion")]
        public double RecoveredPerOneMillion { get; set; }

        [JsonProperty("criticalPerOneMillion")]
        public double CriticalPerOneMillion { get; set; }

        [JsonProperty("affectedCountries")]
        public int AffectedCountries { get; set; }
    }
}
