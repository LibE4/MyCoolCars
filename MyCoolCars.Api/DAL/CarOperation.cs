using MyCoolCars.Api.Interface;
using MyCoolCars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCoolCars.Api.DAL
{
    public class CarOperation : ICarOperation
    {
        public List<Car> GetAll()
        {
            var list = new List<Car>();
            list.Add(new Car()
            {
                Make = "MiniCooper",
                Model = "Convertible",
                Year = 2017
            });
            list.Add(new Car()
            {
                Make = "Ford",
                Model = "Sedan",
                Year = 1999
            });
            return list;
        }

        public Car GetById(int id)
        {
            if (id == 0) return default(Car);

            return new Car()
            {
                Make = "MiniCooper",
                Model = "Convertible",
                Year = 2017
            };
        }

        bool ICarOperation.Poster(Car car)
        {
            if (car == null) return false;
            return true;
        }
    }
}