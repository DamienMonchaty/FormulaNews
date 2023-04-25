using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Constructor
    {
        [JsonProperty(PropertyName = "constructorId")]
        public string ConstructorId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }
    }
}
