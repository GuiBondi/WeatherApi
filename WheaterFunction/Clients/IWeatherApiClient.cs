using System;
using System.Threading.Tasks;
using WheaterFunction.Dtos.Responses;

namespace WheaterFunction.Clients;

public interface IWeatherApiClient
{
    Task<WeatherResponse> GetFutureWeatherAsync(string city, int days);
    Task<WeatherResponse> GetPastWatherAsync(string city, DateTime date);
}