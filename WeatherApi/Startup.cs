using System;
using System.Reflection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WeatherApi;
using WeatherApi.Clients;
using WeatherApi.Clients.Impl;
using WeatherApi.Services;
using WeatherApi.Services.Impl;

[assembly: FunctionsStartup(typeof(Startup))]
namespace WeatherApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddTransient<IWeatherService, WeatherService>();
            builder.Services.AddLogging();
            builder.Services.AddHttpClient<IWeatherApiClient, WheaterApiClient>(client =>
            {
                var baseUrl = builder.GetContext().Configuration["WeatherApi:BaseUrl"];
                if (string.IsNullOrEmpty(baseUrl))
                {
                    throw new ArgumentNullException("WeatherApi:BaseUrl", "A URL base para a API de clima não está configurada.");
                }
                client.BaseAddress = new Uri(baseUrl);
            });
        }
    }
}