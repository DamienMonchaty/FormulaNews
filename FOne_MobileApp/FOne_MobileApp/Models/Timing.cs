using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Timing
    {
        [JsonProperty(PropertyName = "driverId")]
        public string DriverId { get; set; }
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
    }
}
