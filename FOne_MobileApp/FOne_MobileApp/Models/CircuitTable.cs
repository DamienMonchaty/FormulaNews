using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class CircuitTable
    {
        [JsonProperty(PropertyName = "Circuits")]
        public List<Circuit> Circuits { get; set; }
    }
}
