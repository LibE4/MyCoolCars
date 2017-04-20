using MyCoolCars.Api.Interface;
using MyCoolCars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCoolCars.Api.DAL
{
    public class TruckOperation : IOperation<Truck>
    {
        public List<Truck> GetAll()
        {
            var list = new List<Truck>();
            list.Add(new Truck()
            {
                Make = "Toyota",
                Model = "Tundra",
                Year = 2017
            });
            list.Add(new Truck()
            {
                Make = "Ford",
                Model = "F250",
                Year = 1999
            });
            return list;
        }

        public Truck GetById(int id)
        {
            if (id == 0) return default(Truck);

            return new Truck()
            {
                Make = "Ford",
                Model = "F250",
                Year = 1999
            };
        }

        public bool Poster(Truck truck)
        {
            if (truck == null) return false;
            return true;
        }
    }
}