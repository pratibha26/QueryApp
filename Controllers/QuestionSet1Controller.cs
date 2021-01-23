using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QueryApp.Models;
namespace QueryApp.Controllers
{
    [Route("api/Q1")]
    [ApiController]
    public class QuestionSet1Controller : ControllerBase {
        private List<City> _allCities = Data.CitiesList();
        
        [HttpGet]
        [Route("AllCitiesStartingWith/{letter}")]
        public ActionResult<City[]> AllCitiesStartingWith(string letter) 
        {
            
            if (string.IsNullOrWhiteSpace(letter)) {
                return NotFound();
            }
            
            //var results = from city in _allCities
                          //where city.CityName.StartsWith(letter)
                          //select city;
            
            var results = _allCities.Where(x => x.CityName.StartsWith(letter)).ToList();
            return results.ToArray();
        }
        
        [HttpGet]
        [Route("CitiesWithPopulationOver")]
        public ActionResult<City[]> CitiesWithPopulationOver(int population)
        {
            var results = from city in _allCities
				where city.Population > population
				select city;
            return results.ToArray();
        }

        [HttpGet]
        [Route("AllCitiesThatIncludeTheLetter/{letter}")]
        public ActionResult<City[]> AllCitiesThatIncludeTheLetter(string letter)
        {
           if (string.IsNullOrWhiteSpace(letter)) {
                return NotFound();
            }
            var results = from city in _allCities
                where city.CityName.ToUpper().Contains(letter.ToUpper())
                select city;
            return results.ToArray();
        }

        [HttpGet]
        [Route("AllCitiesInState/{stateAbbreviation}")]
        public ActionResult<City[]> AllCitiesInState(string stateAbbreviation)
        {
           if (string.IsNullOrWhiteSpace(stateAbbreviation)) {
                return NotFound();
            }
            var results = from city in _allCities
                where city.State.ToUpper().Equals(stateAbbreviation.ToUpper())
                select city;
            return results.ToArray();
        }
        
        [HttpGet]
        [Route("CitiesSortedByNameAndState")]
        public ActionResult<City[]> CitiesSortedByNameAndState(int page, int resultsPerPage)
        {
           var results = from city in _allCities
				orderby city.CityName, city.State
				select city;
                var Pageresults= results.Skip((page-1)*resultsPerPage).Take(resultsPerPage);
            return Pageresults.ToArray();
        }
    }
}