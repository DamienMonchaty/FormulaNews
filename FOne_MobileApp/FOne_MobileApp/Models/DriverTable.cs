using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class DriverTable
    {
        [JsonProperty(PropertyName = "Drivers")]
        public List<Driver> Drivers { get; set; }
    }
}
