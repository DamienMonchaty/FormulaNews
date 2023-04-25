using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class StandingsLists
    {
        [JsonProperty(PropertyName = "DriverStandings")]
        public List<DriverStandings> DriverStandings { get; set; }

        [JsonProperty(PropertyName = "ConstructorStandings")]
        public List<ConstructorStandings> ConstructorStandings { get; set; }  
    }
}
