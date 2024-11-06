using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WheaterFunction.Dtos.Responses;

namespace WheaterFunction.Clients;

public class WeatherApiClient(HttpClient httpClient) : IWeatherApiClient
{
    private string apikey = "5c8160f438a44dc58c6191328240511";
    public async Task<WeatherResponse> GetFutureWeatherAsync(string city, int days)
    {
       var response = await httpClient.GetAsync($"/forecast.json?key={apikey}&q={city}&days={days}");
       response.EnsureSuccessStatusCode();
       return await response.Content.ReadFromJsonAsync<WeatherResponse>();
    }

    public async Task<WeatherResponse> GetPastWatherAsync(string city, DateTime date)
    {
        var dateString = date.ToString("yyyy-MM-dd");
        var response = await httpClient.GetAsync($"/history.json?key=Y{apikey}&q={city}&dt={dateString}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<WeatherResponse>();
    }
}