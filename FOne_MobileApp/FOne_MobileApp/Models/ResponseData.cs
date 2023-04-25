using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class ResponseData
    {
        [JsonProperty(PropertyName = "CircuitTable")]
        public CircuitTable CircuitTable { get; set; }

        [JsonProperty(PropertyName = "ConstructorTable")]
        public ConstructorTable ConstructorTable { get; set; }

        [JsonProperty(PropertyName = "DriverTable")]
        public DriverTable DriverTable { get; set; }

        [JsonProperty(PropertyName = "RaceTable")]
        public RaceTable RaceTable { get; set; }

        [JsonProperty(PropertyName = "StandingsTable")]
        public StandingsTable StandingsTable { get; set; }
    }
}
