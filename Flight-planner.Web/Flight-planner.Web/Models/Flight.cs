namespace Flight_planner.Web.Models
{
    public class Flight
    {
        public int Id { set; get; }
        public Airport To { set; get; }
        public Airport From { set; get; }
        public string Carrier { set; get; }
        public string DepartureTime { set; get; }
        public string ArrivalTime { set; get; }
    }
}