using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WheaterFunction.Clients;
using WheaterFunction.Dtos.Responses;
using WheaterFunction.Queries;

namespace WheaterFunction.Handlers;

public class GetPastWeatherQueryHandler(IWeatherApiClient client)
    : IRequestHandler<GetHistoricalQuery, List<WeatherResponse>>
{
    public async Task<List<WeatherResponse>> Handle(GetHistoricalQuery request, CancellationToken cancellationToken)
    {
        var teste = new List<WeatherResponse>();
        foreach (var date in request.Dates)
        {
            var result = await client.GetPastWatherAsync(request.Location, date);
            teste.Add(result);
        }

        return teste;
    }
}