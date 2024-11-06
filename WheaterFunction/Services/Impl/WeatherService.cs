using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using WheaterFunction.Clients;
using WheaterFunction.Dtos.Responses;
using WheaterFunction.Queries;

namespace WheaterFunction.Services.Impl;

public class WeatherService (IMediator mediator) :  IWeatherService
{

    public async Task Handle(string city)
    {
        var query = new GetHistoricalQuery("Curitiba", GetPreviousWeekDays(DateTime.Now));
        await mediator.Send(query);
        var query2 = new GetForecastQuery("Curitiba", DiasParaDomingo());
        await mediator.Send(query2);
    }
 public static List<DateTime> GetPreviousWeekDays(DateTime currentDate)
{
    var previousDates = new List<DateTime>();
    switch (currentDate.DayOfWeek)
    {
        case DayOfWeek.Monday:
            // Segunda-feira não possui dias anteriores na mesma semana
            break;

        case DayOfWeek.Tuesday:
            // Adiciona segunda-feira
            previousDates.Add(currentDate.AddDays(-1));
            break;

        case DayOfWeek.Wednesday:
            // Adiciona terça e segunda-feira
            previousDates.Add(currentDate.AddDays(-1));
            previousDates.Add(currentDate.AddDays(-2));
            break;

        case DayOfWeek.Thursday:
            previousDates.Add(currentDate.AddDays(-1));
            previousDates.Add(currentDate.AddDays(-2));
            previousDates.Add(currentDate.AddDays(-3));
            break;

        case DayOfWeek.Friday:
            
            previousDates.Add(currentDate.AddDays(-1));
            previousDates.Add(currentDate.AddDays(-2));
            previousDates.Add(currentDate.AddDays(-3));
            previousDates.Add(currentDate.AddDays(-4));
            break;

        case DayOfWeek.Saturday:
            previousDates.Add(currentDate.AddDays(-1));
            previousDates.Add(currentDate.AddDays(-2));
            previousDates.Add(currentDate.AddDays(-3));
            previousDates.Add(currentDate.AddDays(-4));
            previousDates.Add(currentDate.AddDays(-5));
            break;

        case DayOfWeek.Sunday:
            previousDates.Add(currentDate.AddDays(-1));
            previousDates.Add(currentDate.AddDays(-2));
            previousDates.Add(currentDate.AddDays(-3));
            previousDates.Add(currentDate.AddDays(-4));
            previousDates.Add(currentDate.AddDays(-5));
            previousDates.Add(currentDate.AddDays(-6));
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    return previousDates;
}
 
public static int DiasParaDomingo()
{
    DayOfWeek hoje = DateTime.Now.DayOfWeek;
    int diasRestantes = DayOfWeek.Saturday - hoje + 1;
    return diasRestantes;
}
    // Lista para armazenar os dados do clima de cada dia da semana
//     var weeklyWeather = new List<WeatherDay>();
//
//     // Identificar o dia atual e os dias anteriores e posteriores até o final da semana
//     DateTime today = DateTime.Today;
//     var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
//     var endOfWeek = startOfWeek.AddDays(6);
//
//     // Iterar sobre cada dia da semana, começando pela segunda-feira até domingo
//     for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
//     {
//         WeatherData weatherData;
//
//         if (date < today)
//         {
//             // Dados históricos para dias anteriores
//             weatherData = await _mediator.Send(new GetHistoricalQuery(location, date));
//         }
//         else
//         {
//             // Dados de previsão para hoje e dias futuros
//             int daysAhead = (date - today).Days;
//             if (daysAhead == 0)
//             {
//                 // Dados atuais
//                 weatherData = await _mediator.Send(new GetForecastQuery(location, 1));
//             }
//             else
//             {
//                 // Previsão futura
//                 weatherData = await _mediator.Send(new GetForecastQuery(location, daysAhead + 1));
//             }
//         }
//
//         // Extrair as informações essenciais para o relatório
//         var weatherDay = new WeatherDay
//         {
//             Date = date.ToString("dddd"), // Nome do dia (ex: Segunda, Terça)
//             Temperature = weatherData.Current.TempC,
//             Condition = weatherData.Current.Condition.Text
//         };
//
//         weeklyWeather.Add(weatherDay);
//     }
//
//     return new WeatherReport
//     {
//         Location = location,
//         Days = weeklyWeather
//     };
// }

}