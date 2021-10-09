using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class AirportCodeValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests?.From?.Airport) &&
                !string.IsNullOrEmpty(requests?.To?.Airport);
        }
    }
}
