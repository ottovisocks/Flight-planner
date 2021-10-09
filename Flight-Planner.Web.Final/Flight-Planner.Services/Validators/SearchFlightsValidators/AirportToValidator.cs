using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.SearchFlightsValidators
{
    public class AirportToValidator : ISearchFlightsValidator
    {
        public bool IsValid(SearchFlightRequest requests)
        {
            return !string.IsNullOrEmpty(requests.To);
        }
    }
}
