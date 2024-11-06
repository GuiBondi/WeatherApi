using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WeatherApi.Clients;
using WeatherApi.Dtos.Responses;
using WeatherApi.Queries;

namespace WeatherApi.Handlers;

public class GetFutureWeatherQueryHandler(IWeatherApiClient client)
    : IRequestHandler<GetFutureWeatherQuery, WeatherResponse>
{
    public async Task<WeatherResponse> Handle(GetFutureWeatherQuery request, CancellationToken cancellationToken) =>
        await client.GetFutureWeatherAsync(request.City, request.Days);
}