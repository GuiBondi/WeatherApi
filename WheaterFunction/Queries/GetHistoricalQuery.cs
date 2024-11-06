using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WheaterFunction.Clients;
using WheaterFunction.Dtos.Responses;

namespace WheaterFunction.Queries;

// public class GetHistoricalQuery(IWeatherApiClient client) : IRequest<WeatherResponse>
// {
//     public async Task<WeatherResponse> Handle(string city, DateTime date, CancellationToken cancellationToken) => await client.GetPastWatherAsync(city, date);
// }
public class GetHistoricalQuery(string city, List<DateTime> dates) : IRequest<List<WeatherResponse>>
{
    public string Location { get; } = city;
    public List<DateTime> Dates { get; } = dates;
}