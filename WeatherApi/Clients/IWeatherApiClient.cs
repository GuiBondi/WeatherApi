using System;
using System.Threading.Tasks;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Clients;

public interface IWeatherApiClient
{
    Task<WeatherResponse> GetFutureWeatherAsync(string city, int days);
    Task<WeatherResponse> GetPastWatherAsync(string city, DateTime date);
}