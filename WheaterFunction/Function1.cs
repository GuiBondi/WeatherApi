using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WheaterFunction.Services;

public class ClimaFunction(IWeatherService weatherService)
{
    [FunctionName("ObterClima")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "api/clima/{cidade?}")]
        HttpRequest req,
        string cidade,
        ILogger log)
    {
        log.LogInformation("Função de API de clima processou uma solicitação.");

        // Tenta obter a cidade do parâmetro da URL ou do corpo da requisição
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        cidade = cidade ?? data?.cidade;
        await weatherService.Handle(cidade);
        // Mensagem de resposta
        string responseMessage = string.IsNullOrEmpty(cidade)
            ? "Esta função de API de clima foi executada com sucesso. Forneça uma cidade na rota ou no corpo da solicitação para uma resposta personalizada."
            : $"Olá! A previsão do clima para a cidade de {cidade} será exibida aqui em uma implementação futura.";

        return new OkObjectResult(responseMessage);
    }
}