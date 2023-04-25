using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class DriverStandings
    {
        [JsonProperty(PropertyName = "position")]
        public string position { get; set; }
        [JsonProperty(PropertyName = "positionText")]
        public string positionText { get; set; }
        [JsonProperty(PropertyName = "points")]
        public string points { get; set; }
        [JsonProperty(PropertyName = "wins")]
        public string wins { get; set; }
        [JsonProperty(PropertyName = "Driver")]
        public Driver Driver { get; set; }
        [JsonProperty(PropertyName = "Constructors")]
        public List<Constructor> Constructors { get; set; }
    }
}
