using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WheaterFunction.Clients;
using WheaterFunction.Dtos.Responses;

namespace WheaterFunction.Queries;

public class GetForecastQuery(string location, int days) : IRequest<WeatherResponse>
{
    public string Location { get; } = location;
    public int Days { get; } = days;
}
