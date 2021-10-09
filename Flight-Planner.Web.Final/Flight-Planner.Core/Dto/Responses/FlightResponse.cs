namespace Flight_Planner.Core.Dto.Responses
{
    public class FlightResponse
    {
        public int Id { set; get; }
        public AirportResponse To { set; get; }
        public AirportResponse From { set; get; }
        public string Carrier { set; get; }
        public string DepartureTime { set; get; }
        public string ArrivalTime { set; get; }
    }
}
