using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class FirstPractice
    {
        [JsonProperty(PropertyName = "date")]
        public string date { get; set; }
        [JsonProperty(PropertyName = "time")]
        public string time { get; set; }
    }
}
