using MediatR;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Queries;

public class GetFutureWeatherQuery(string city, int days) : IRequest<WeatherResponse>
{
    public string City { get; } = city;
    public int Days { get; } = days;
}
