
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QueryApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public String CityName { get; set; }
        public String State { get; set; }
        public int Population { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            City otherCity = obj as City;
            if (otherCity == null) return false;
            return CityName == otherCity.CityName && State == otherCity.State;
        }

        public override int GetHashCode()
        {
            return (CityName + "|" + State).GetHashCode();
        }

        public string Display()
        {
            return CityName + " (" + State + ") - pop. " + Population;
        }
    }
}
            