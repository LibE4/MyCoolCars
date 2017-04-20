using MyCoolCars.Api.Models;
using MyCoolCars.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCoolCars.Api.DAL
{
    public class DogOperation : IDogOperation
    {
        public List<Dog> GetAll()
        {
            var list = new List<Dog>();
            list.Add(new Dog()
            {
                Name = "Buffy",
                Breed = "Pomeranion",
                Height = 0.8,
                Weight = 8.5
            });
            list.Add(new Dog()
            {
                Name = "Ghost",
                Breed = "Bichon",
                Height = 0.7,
                Weight = 16
            });
            return list;
        }

        public Dog GetById(int id)
        {
            if (id == 0) return null;

            return new Dog
            {
                Name = "Buffy",
                Breed = "Pomeranion",
                Height = 0.8,
                Weight = 8.5
            };
        }
        bool IDogOperation.Poster(Dog dog)
        {
            if (dog == null) return false;
            return true;
        }
    }
}