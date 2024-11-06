using System.Collections.Generic;
using Newtonsoft.Json;

namespace WheaterFunction.Dtos.Responses;

public class WeatherResponse
{
    public Location Location { get; set; }
    public Current Current { get; set; }
    public Forecast Forecast { get; set; }
}

public class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    // Outras propriedades...
}

public class Current
{
    public double TempC { get; set; }
    // Outras propriedades...
}

public class Forecast
{
    [JsonProperty("forecastday")]
    public List<ForecastDay> Forecastday { get; set; }
}

public class ForecastDay
{
    public string Date { get; set; }
    public Day Day { get; set; }
    // Outras propriedades...
}

public class Day
{
    [JsonProperty("maxtemp_c")]
    public double MaxtempC { get; set; }
    [JsonProperty("mintemp_c")]
    public double MintempC { get; set; }
    [JsonProperty("avgtemp_c")]
    public double AvgtempC { get; set; }
    // Outras propriedades...
}

public class DailyTemperature
{
    public string Date { get; set; }
    public double MaxTempC { get; set; }
    public double MinTempC { get; set; }
    public double AvgTempC { get; set; }
}

