using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherApi.Services;
using System.Net.Http;
using System;

namespace WeatherApi;

public class GetWeather(IWeatherService weatherService)
{
    [FunctionName("GetWeather")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get",Route = "weather/{city?}")]
        HttpRequest req, string city,ILogger log)
    {
        log.LogInformation("Função de API de clima processou uma solicitação.");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        city = city ?? data?.cidade;
        try
        {
            var result = await weatherService.GetWeatherAsync(city);
            string responseMessage = JsonConvert.SerializeObject(result);
            return new OkObjectResult(responseMessage);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            log.LogError("Bad Request ao consultar a API: {Message}", ex.Message);
            return new BadRequestObjectResult("A requisição está incorreta. Verifique os parâmetros e tente novamente.");
        }
        catch (Exception ex)
        {
            log.LogError("Erro ao consultar a API: {Message}", ex.Message);
            throw;
        }
    }
}
