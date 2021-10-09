using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class AirportCityValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests?.From?.City) &&
                !string.IsNullOrEmpty(requests?.To?.City);
        }
    }
}
