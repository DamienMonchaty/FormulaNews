using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Location
    {
        [JsonProperty(PropertyName = "lat")]
        public string Lat { get; set; }
        [JsonProperty(PropertyName = "long")]
        public string Long { get; set; }
        [JsonProperty(PropertyName = "locality")]
        public string Locality { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
