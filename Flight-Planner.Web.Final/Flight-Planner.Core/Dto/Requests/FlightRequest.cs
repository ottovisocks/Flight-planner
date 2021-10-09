namespace Flight_Planner.Core.Dto.Requests
{
    public class FlightRequest
    {
        public AirportRequest To { set; get; }
        public AirportRequest From { set; get; }
        public string Carrier { set; get; }
        public string DepartureTime { set; get; }
        public string ArrivalTime { set; get; }
    }
}
