using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Race
    {
        [JsonProperty(PropertyName = "season")]
        public string Season { get; set; }
        [JsonProperty(PropertyName = "round")]
        public string Round { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "raceName")]
        public string RaceName { get; set; }
        [JsonProperty(PropertyName = "Circuit")]
        public Circuit Circuit { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
        [JsonProperty(PropertyName = "Laps")]
        public List<Lap> Laps { get; set; }
        [JsonProperty(PropertyName = "Results")]
        public List<Result> Results { get; set; }
    }
}
