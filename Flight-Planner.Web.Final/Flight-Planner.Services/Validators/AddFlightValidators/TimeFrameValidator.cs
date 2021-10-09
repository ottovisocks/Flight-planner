using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;
using System;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class TimeFrameValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            try
            {
                return DateTime.Parse(requests.ArrivalTime) > DateTime.Parse(requests.DepartureTime);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
