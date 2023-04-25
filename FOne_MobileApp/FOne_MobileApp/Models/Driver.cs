    using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FOne_MobileApp.Models
{
    public class Driver
    {
        [JsonProperty(PropertyName = "driverId")]
        public string DriverId { get; set; }
        [JsonProperty(PropertyName = "permanentNumber")]
        public string PermanentNumber { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "givenName")]
        public string GivenName { get; set; }
        [JsonProperty(PropertyName = "familyName")]
        public string FamilyName { get; set; }
        [JsonProperty(PropertyName = "dateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; }
        public ImageSource Image { get; set; }
    }
}
