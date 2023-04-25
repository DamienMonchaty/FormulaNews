using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class Result
    {
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "points")]
        public string Points { get; set; }
        [JsonProperty(PropertyName = "Driver")]
        public Driver Driver { get; set; }
        [JsonProperty(PropertyName = "Constructor")]
        public Constructor Constructor { get; set; }
        [JsonProperty(PropertyName = "grid")]
        public string Grid { get; set; }
        [JsonProperty(PropertyName = "laps")]
        public string Laps { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "Time")]
        public Time Time { get; set; }
        [JsonProperty(PropertyName = "FastestLap")]
        public FastestLap FastestLap { get; set; }
    }
}
