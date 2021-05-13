using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Entities;

namespace Weather.Interfaces
{
    public interface IWeatherService
    {
        Task<string> Search(string query);
        Task<string> GetCurrentWeather(City city);
        Task AddToFavorites(City city);
        Task DeleteFavorite(City city);
    }
}
