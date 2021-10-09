using Flight_Planner.Core.Dto.Requests;

namespace Flight_Planner.Core.Services
{
    public interface IAddFlightValidator
    {
        bool IsValid(FlightRequest requests);
    }
}
