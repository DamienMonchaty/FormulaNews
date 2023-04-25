using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class RaceTable
    {
        [JsonProperty(PropertyName = "Races")]
        public List<Race> Races { get; set; }
    }
}
