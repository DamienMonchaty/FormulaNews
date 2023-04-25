using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class FastestLap
    {
        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }
        [JsonProperty(PropertyName = "lap")]
        public string Lap { get; set; }
        [JsonProperty(PropertyName = "Time")]
        public Time Time { get; set; }
        [JsonProperty(PropertyName = "AverageSpeed")]
        public AverageSpeed AverageSpeed { get; set; }
    }
}
