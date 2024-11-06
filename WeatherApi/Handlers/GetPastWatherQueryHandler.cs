using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WeatherApi.Clients;
using WeatherApi.Dtos.Responses;
using WeatherApi.Queries;

namespace WeatherApi.Handlers;

public class GetPastWeatherQueryHandler(IWeatherApiClient client)
    : IRequestHandler<GetPastWeatherQuery, List<WeatherResponse>>
{
    public async Task<List<WeatherResponse>> Handle(GetPastWeatherQuery request, CancellationToken cancellationToken)
    {
        var tasks = request.Dates.Select(date => client.GetPastWatherAsync(request.City, date));
        var weatherResponses = await Task.WhenAll(tasks);
        return weatherResponses.ToList();
    }
}