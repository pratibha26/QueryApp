using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QueryApp.Models;
namespace QueryApp.Controllers
{
    [Route("api/Q2")]
    [ApiController]
    public class QuestionSet2Controller : ControllerBase {
        private List<City> _allCities = Data.CitiesList();
        
        [HttpGet("{id}")]
        public ActionResult<City> Get([FromRoute]int? id) {
            var result = from city in _allCities
				where city.Id == id
				select city;
            return result.First();
        }

        [HttpGet]
        [Route("CityWithTheLongestName")]
        public ActionResult<City> CityWithTheLongestName() 
        {
            var max = _allCities.Max(city => city.CityName.Length);
            var result = _allCities.Where(city => city.CityName.Length == max);
            return result.First();
        }

        [HttpGet]
        [Route("CityWithTheShortestName")]
        public ActionResult<City> CityWithTheShortestName() 
        {
            var min = _allCities.Min(city => city.CityName.Length);
            var result = _allCities.Where(city => city.CityName.Length == min);
            return result.First();
        }

        [HttpGet]
        [Route("CityWithTheLargestPopulation")]
        public ActionResult<City> CityWithTheLargestPopulation() 
        {
            var max = _allCities.Max(city => city.Population);
            var result = _allCities.Where(city => city.Population == max);
            return result.First();
        }

        [HttpGet]
        [Route("CityWithTheLargestPopulation/{state}")]
        public ActionResult<City> CityWithTheLargestPopulationByState(string state) 
        {
            var StateCities = _allCities.Where(city => city.State == state);
            var max = StateCities.Max(city => city.Population);
            var result = StateCities.Where(city => city.Population == max);
            return result.First();
        }
        

        [HttpGet]
        [Route("CityWithTheLowestPopulation")]
        public ActionResult<City> CityWithTheLowestPopulation() 
        {
            var min = _allCities.Min(city => city.Population);
            var result = _allCities.Where(city => city.Population == min);
            return result.First();
        }
        
    }
}