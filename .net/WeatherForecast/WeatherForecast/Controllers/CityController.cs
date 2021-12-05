using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherForecast.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        // GET: api/<CityController>
        [HttpGet]
        [Route("api/[controller]/GetNumOfFavorites")]
        public int Get()
        {
            return CityManager.GetFavoriteCities();
        }

        [HttpGet]
        [Route("api/[controller]/AddCityToFavorites")]
        public int Get(string city)
        {
           return CityManager.AddToFavoriteCities(city);
        }

        [HttpPost]
        [Route("api/[controller]/AddToSearch")]
        public void AddToSearch([FromBody] Search search)
        {
             CityManager.AddToSearch(search);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllSearches")]
        public Search[] GetAllSearches()
        {
           return CityManager.GetAllSearches();
        }
    }
}
