using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QueryApp.Models;
namespace QueryApp.Controllers
{
    [Route("api/Q3")]
    [ApiController]
    public class QuestionSet3Controller : ControllerBase {
        private List<City> _allCities = Data.CitiesList();
        
        [HttpGet]
        [Route("TotalPopulationInAllCities")]
        public ActionResult<int> TotalPopulationInAllCities()
        {
            var result = _allCities.Sum(city => city.Population);
            return result;
        }

        [HttpGet]
        [Route("AveragePopulationAccrossAllCities")]
        public ActionResult<double> AveragePopulationAccrossAllCities()
        {
            var result = _allCities.Average(city => city.Population);
            return result;
        }

        [HttpGet]
        [Route("AveragePopulationInState/{stateAbbreviation}")]
        public ActionResult<double> AveragePopulationInState(string stateAbbreviation)
        {
            var StateCities = _allCities.Where(city => city.State == stateAbbreviation);
            var result = StateCities.Average(city => city.Population);
            return result;
        }  

        [HttpGet]
        [Route("CountOfAllCitiesWithPopulationLessThan")]
        public ActionResult<double> CountOfAllCitiesWithPopulationLessThan(int? population)
        {
            var result = _allCities.Count(city => city.Population < population);
            return result;
        }

        [HttpGet]
        [Route("StateWithMostCities")]
        public ActionResult<string> StateWithMostCities()
        {
            var result = _allCities.GroupBy(city => city.State).Select(StateGroup => new { 
                             StateName = StateGroup.Key, 
                             CountCities = StateGroup.Count() 
                        }).OrderByDescending(x => x.CountCities).First();
            return result.StateName;

				

        }
        
    }
}