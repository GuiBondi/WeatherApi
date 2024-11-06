# Weather API Function

## Descrição

Este projeto implementa uma Azure Function em C# que consulta uma API de clima e retorna dados climáticos formatados, incluindo temperatura atual, condição climática e previsão da semana. A função utiliza o padrão CQRS com MediatR para estruturar as consultas e comandos, seguindo os princípios SOLID para modularidade e extensibilidade.

## Funcionalidades

- **Consulta de Clima**: Retorna informações climáticas essenciais como temperatura e condições atuais.
- **Previsão da Semana**: Exibe o clima de dias anteriores, o dia atual, e os próximos dias até o domingo.
- **Padrões de Projeto**: Implementação de CQRS com MediatR para comandos e queries, com uso de princípios SOLID.

## Estrutura do Projeto

- **Azure Function (GetWeather)**: Função HTTP Trigger que recebe o nome da cidade como parâmetro.
- **CQRS com MediatR**: Separação entre Queries e Commands para melhorar a organização e manutenibilidade.
- **DateUtilities**: Utilitário para obter os dias anteriores e calcular os dias restantes da semana.
- **WeatherApiClient**: Cliente HTTP para integração com a API de clima, configurado para buscar dados climáticos passados e futuros.

## Configuração

### Pré-requisitos

- **.NET 8** 
- **Azure Functions Core Tools** para execução local.
- Conta na [WeatherAPI](https://www.weatherapi.com/)  para obtenção de uma chave de API.

### Passo a Passo

1. **Clonar o Repositório**
    `git clone https://github.com/GuiBondi/WeatherApi.git cd WeatherApi`
    
2. **Configurar Variáveis de Ambiente** No arquivo `local.settings.json`, adicione as variáveis de ambiente necessárias:
    `{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "WeatherApi:BaseUrl": "https://api.weatherapi.com/v1/",
        "WeatherApi:ApiKey": "SUA_CHAVE_DA_API"
    }
}`
    
3. **Instalar Dependências** Execute o comando abaixo para restaurar os pacotes:
    
    `dotnet restore`
    
4. **Executar a Função Localmente**

    `func start`
    
5. **Testar a API** Após iniciar, acesse a API pelo endpoint local:
    
    `GET http://localhost:7071/api/weather/{city}`
    
    Substitua `{city}` pelo nome da cidade que deseja consultar (para cidades com nomes compostos deve se usar _ para separar por exemplo Rio de janeiro tem que ser Rio_de_janeiro)
    
6. **Retorno esperado**  [
    {"Date":"2024-11-04","Condition":"Light rain shower","Temperature":"17.2"},
    {"Date":"2024-11-05","Condition":"Light rain shower","Temperature":"18.9"},
    {"Date":"2024-11-06","Condition":"Moderate rain","Temperature":"19.9"},
    {"Date":"2024-11-07","Condition":"Moderate rain","Temperature":"19.6"},
    {"Date":"2024-11-08","Condition":"Patchy rain nearby","Temperature":"16.5"},
    {"Date":"2024-11-09","Condition":"Patchy rain nearby","Temperature":"14.5"},
    {"Date":"2024-11-10","Condition":"Cloudy","Temperature":"15.8"}
]

## Estrutura de Código

- **`GetWeather.cs`**: Azure Function principal para obter o clima.
- **`Startup.cs`**: Configuração de injeção de dependências, incluindo `IWeatherService`, `IWeatherApiClient` e MediatR.
- **`WeatherService.cs`**: Implementa a lógica de negócios para consultas de clima, combinando clima passado e futuro.
- **`DateUtilities.cs`**: Utilitários para cálculo de datas passadas e dias restantes da semana.
- **`WeatherApiClient.cs`**: Cliente HTTP para chamadas à API de clima.
- **`GetPastWeatherQuery` e `GetFutureWeatherQuery`**: Queries para solicitar dados de clima passado e futuro.
- **Handlers**: `GetPastWeatherQueryHandler` e `GetFutureWeatherQueryHandler` processam as queries usando o `WeatherApiClient`.

## Bibliotecas Utilizadas

- **MediatR**: Implementação de CQRS para separação de comandos e consultas.
- **Azure Functions**: Infraestrutura para execução de funções de maneira escalável.
- **Newtonsoft.Json**: Para manipulação de dados JSON.
