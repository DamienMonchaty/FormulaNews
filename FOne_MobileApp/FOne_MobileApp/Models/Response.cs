using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Response
    {
        [JsonProperty(PropertyName = "MRData")]
        public ResponseData data { get; set; }
    }
}
