using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class ConstructorStandings
    {
        [JsonProperty(PropertyName = "position")]
        public string position { get; set; }
        [JsonProperty(PropertyName = "positionText")]
        public string positionText { get; set; }
        [JsonProperty(PropertyName = "points")]
        public string points { get; set; }
        [JsonProperty(PropertyName = "wins")]
        public string wins { get; set; }
        [JsonProperty(PropertyName = "Constructor")]
        public Constructor Constructor { get; set; }
    }
}
