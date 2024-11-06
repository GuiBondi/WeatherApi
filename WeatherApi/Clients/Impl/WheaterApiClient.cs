using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApi.Dtos.Responses;

namespace WeatherApi.Clients.Impl;

public class WheaterApiClient(HttpClient httpClient, IConfiguration configuration) : IWeatherApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly string _apiKey = configuration["WeatherApi:ApiKey"] ?? throw new ArgumentNullException("WeatherApi:ApiKey", "A chave da API de clima n�o est� configurada.");
    public async Task<WeatherResponse> GetFutureWeatherAsync(string city, int days)
    {
        var response = await httpClient.GetAsync($"forecast.json?key={_apiKey}&q={city}&days={days}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<WeatherResponse>();
        return result;
    }

    public async Task<WeatherResponse> GetPastWatherAsync(string city, DateTime date)
    {
        var dateString = date.ToString("yyyy-MM-dd");
        var response = await httpClient.GetAsync($"history.json?key={_apiKey}&q={city}&dt={dateString}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<WeatherResponse>();
        return result;
    }
}