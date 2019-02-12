using Newtonsoft.Json;


namespace MvcWebapiNhiberAutofac.Models
{
    public class ShowDescription
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cast")]
        public CastDesciption[] Cast { get; set; }
    }

    public class CastDesciption
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
    }
}