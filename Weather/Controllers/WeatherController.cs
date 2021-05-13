using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Entities;
using Weather.Interfaces;

namespace Weather.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        [HttpGet]
        [ActionName("Search")]
        public async Task<ActionResult<string>> Search()
        
        {
            string query = ""; 
            var res = await _weatherService.Search(query);
            return res;
        }


        [HttpGet]
        [ActionName("GetCurrentWeather")]
        public async Task<string> GetCurrentWeather(City city)
        {
            return await _weatherService.GetCurrentWeather(city);
        }


        [HttpGet]
        [ActionName("AddToFavorites")]
        public async Task<ActionResult> AddToFavorites(City city)
        {
            await _weatherService.AddToFavorites(city);
            return Ok();
        }

        [HttpGet]
        [ActionName("DeleteFavorite")]
        public async Task<ActionResult> DeleteFavorite(City city)
        {
           await _weatherService.DeleteFavorite(city);
           return Ok();
        }
    }


}