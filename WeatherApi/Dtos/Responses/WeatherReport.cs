using System.Collections.Generic;

namespace WeatherApi.Dtos.Responses;

public class WeatherReport
{
    public string Location { get; set; }
    public List<WeatherDay> Days { get; set; }
}

public class WeatherDay
{
    public string Date { get; set; }
    public double Temperature { get; set; }
    public string Condition { get; set; }
}