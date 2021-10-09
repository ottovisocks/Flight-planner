using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class AirportCountryValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests?.From?.Country) &&
                !string.IsNullOrEmpty(requests?.To?.Country);
        }
    }
}
