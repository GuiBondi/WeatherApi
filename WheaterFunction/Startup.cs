using System;
using System.Reflection;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WheaterFunction.Clients;

[assembly: FunctionsStartup(typeof(WheaterFunction.Startup))]
namespace WheaterFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //builder.Services.AddLogging();
            builder.Services.AddHttpClient<IWeatherApiClient, WeatherApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.weatherapi.com/v1/");
            });
        }
    }
}