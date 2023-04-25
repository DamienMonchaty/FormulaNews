using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FOne_MobileApp.Models
{
    public class ConstructorTable
    {
        [JsonProperty(PropertyName = "Constructors")]
        public List<Constructor> Constructors { get; set; }
    }
}
