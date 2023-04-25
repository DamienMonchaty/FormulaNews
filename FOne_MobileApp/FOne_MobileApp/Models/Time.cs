using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Time
    {
        [JsonProperty(PropertyName = "millis")]
        public string Millis { get; set; }
        [JsonProperty(PropertyName = "time")]
        public string ExtraTime { get; set; }
    }
}
