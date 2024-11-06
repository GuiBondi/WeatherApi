using MediatR;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Queries;

public class GetFutureWeatherQuery(string location, int days) : IRequest<WeatherResponse>
{
    public string Location { get; } = location;
    public int Days { get; } = days;
}
