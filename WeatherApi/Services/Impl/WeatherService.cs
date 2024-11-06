using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using WeatherApi.Dtos.Responses;
using WeatherApi.Mappers;
using WeatherApi.Queries;
using WeatherApi.Utilities;

namespace WeatherApi.Services.Impl;

public class WeatherService(IMediator mediator) : IWeatherService
{
    public async Task<List<FormattedWeatherResponse>> GetWeatherAsync(string city)
    {
        var pastWeatherTask = mediator.Send(new GetPastWeatherQuery(city, DateUtilities.GetPreviousWeekDays(DateTime.Now)));
        var futureWeatherTask = mediator.Send(new GetFutureWeatherQuery(city, DateUtilities.GetDaysRemaining()));
        await Task.WhenAll(pastWeatherTask, futureWeatherTask);
        return FormatWeatherResponse(pastWeatherTask.Result, futureWeatherTask.Result); ;
    }
    public static List<FormattedWeatherResponse> FormatWeatherResponse(List<WeatherResponse> pastWeatherResult, WeatherResponse futureWeatherResult)
    {
        var combinedWeather = WeatherResponseMapper.MapPastWeather(pastWeatherResult);
        combinedWeather.AddRange(WeatherResponseMapper.MapFutureWeather(futureWeatherResult));
        return combinedWeather.OrderBy(weather => DateTime.Parse(weather.Date)).ToList();
    }
}