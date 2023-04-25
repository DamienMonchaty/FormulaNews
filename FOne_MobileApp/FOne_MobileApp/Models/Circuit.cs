using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Circuit
    {
        [JsonProperty(PropertyName = "circuitId")]
        public string CircuitId { get; set; }
        [JsonProperty(PropertyName = "circuitName")]
        public string CircuitName { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "Location")]
        public Location Location { get; set; }
    }
}
