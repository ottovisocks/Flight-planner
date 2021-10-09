namespace Flight_Planner.Core.Models
{
    public class Flight : Entity
    {
        public Airport To { set; get; }
        public Airport From { set; get; }
        public string Carrier { set; get; }
        public string DepartureTime { set; get; }
        public string ArrivalTime { set; get; }
    }
}
