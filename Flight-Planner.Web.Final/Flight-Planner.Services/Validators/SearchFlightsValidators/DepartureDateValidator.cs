using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.SearchFlightsValidators
{
    public class DepartureDateValidator : ISearchFlightsValidator
    {
        public bool IsValid(SearchFlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests.DepartureDate);
        }
    }
}
