using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class AverageSpeed
    {
        [JsonProperty(PropertyName = "units")]
        public string Units { get; set; }
        [JsonProperty(PropertyName = "speed")]
        public string Speed { get; set; }
    }
}
