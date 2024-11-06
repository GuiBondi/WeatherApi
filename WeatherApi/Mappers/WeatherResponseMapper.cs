using System.Collections.Generic;
using System.Linq;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Mappers
{
    public static class WeatherResponseMapper
    {
        public static List<FormattedWeatherResponse> MapPastWeather(List<WeatherResponse> pastWeatherResult)
        {
            return pastWeatherResult
                .SelectMany(pastWeather => pastWeather.forecast.forecastday.Select(day =>
                    new FormattedWeatherResponse(
                        day.date.ToString(),
                        day.day.condition.text,
                        day.day.avgtemp_c.ToString()
                    )))
                .ToList();
        }

        public static List<FormattedWeatherResponse> MapFutureWeather(WeatherResponse futureWeatherResult)
        {
            return futureWeatherResult.forecast.forecastday.Select(day =>
                new FormattedWeatherResponse(
                    day.date.ToString(),
                    day.day.condition.text,
                    day.day.avgtemp_c.ToString()
                )).ToList();
        }
    }
}
