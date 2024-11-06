using System;
using System.Collections.Generic;
using MediatR;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Queries;

public class GetPastWeatherQuery(string city, List<DateTime> dates) : IRequest<List<WeatherResponse>>
{
    public string City { get; } = city;
    public List<DateTime> Dates { get; } = dates;
}