using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class StandingsTable
    {
        [JsonProperty(PropertyName = "StandingsLists")]
        public List<StandingsLists> StandingsLists { get; set; }
    }
}
