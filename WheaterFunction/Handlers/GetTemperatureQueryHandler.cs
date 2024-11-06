using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WheaterFunction.Clients;
using WheaterFunction.Dtos.Responses;
using WheaterFunction.Queries;

namespace WheaterFunction.Handlers;

public class GetFutureWeatherQueryHandler(IWeatherApiClient client)
    : IRequestHandler<GetForecastQuery, WeatherResponse>
{
    public async Task<WeatherResponse> Handle(GetForecastQuery request, CancellationToken cancellationToken) =>
        await client.GetFutureWeatherAsync(request.Location, request.Days);
}