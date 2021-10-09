using Flight_Planner.Core.Dto.Requests;

namespace Flight_Planner.Core.Services
{
    public interface ISearchFlightsValidator
    {
        bool IsValid(SearchFlightRequest requests);
    }
}
