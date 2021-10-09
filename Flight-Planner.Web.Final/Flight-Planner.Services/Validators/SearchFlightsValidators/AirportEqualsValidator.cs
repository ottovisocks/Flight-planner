using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Services;

namespace Flight_Planner.Services.Validators.SearchFlightsValidators
{
    public class AirportEqualsValidator : ISearchFlightsValidator
    {
        public bool IsValid(SearchFlightRequest requests)
        {
            return requests.To != requests.From;
        }
    }
}
