﻿namespace Flight_Planner.Core.Dto.Requests
{
    public class SearchFlightRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }
    }
}