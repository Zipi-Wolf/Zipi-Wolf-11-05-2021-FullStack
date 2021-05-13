using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Entities;
using Weather.Interfaces;

namespace Weather.Services
{
    public class WeatherService : IWeatherService
    {

        //protected readonly WeatherContext _weatherContext;
        protected readonly IAsyncRepository<City> _favoriteRepo;
        protected readonly IHttpClientService _httpClientService;

        public WeatherService(IAsyncRepository<City> favoriteRepo , IHttpClientService httpClientService)
        {
            _favoriteRepo = favoriteRepo;
            _httpClientService = httpClientService;
        }

        public async Task<string> Search(string query)
        {
           await _httpClientService.OnGet(query);
            string res ="";
            return res;
        }

        public async Task<string> GetCurrentWeather(City city)
        {
            string res = "";
            return res;
        }

        public async Task AddToFavorites(City city)
        {
            await _favoriteRepo.AddAsync(city);
        }

        public async Task DeleteFavorite(City city)
        {
            await _favoriteRepo.DeleteAsync(city);
        }
    }
}
