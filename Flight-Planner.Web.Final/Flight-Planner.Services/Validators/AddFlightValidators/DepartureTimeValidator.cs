using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class DepartureTimeValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests.DepartureTime);
        }
    }
}
