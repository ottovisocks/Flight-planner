using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.AddFlightValidators
{
    public class AirportCodesEqualityValidator : IAddFlightValidator
    {
        public bool IsValid(FlightRequest requests)
        {
            return requests?.From?.Airport?.Trim().ToLower() != requests?.To?.Airport?.Trim().ToLower();
        }
    }
}
