using System.Threading.Tasks;

namespace WheaterFunction.Services;

public interface IWeatherService
{
    Task Handle(string city);
}