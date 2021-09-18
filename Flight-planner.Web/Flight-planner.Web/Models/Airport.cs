using System.Text.Json.Serialization;

namespace Flight_planner.Web.Models
{
    public class Airport
    {
        public string Country { set; get; }
        public string City { set; get; }
        [JsonPropertyName("airport")]
        public string AirportCode { set; get; }
    }
}