using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Services;

public interface IWeatherService
{
    Task<List<FormattedWeatherResponse>> GetWeatherAsync(string city);

}