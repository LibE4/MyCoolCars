using MyCoolCars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolCars.Api.Interface
{
    public interface IDogOperation
    {
        List<Dog> GetAll();
        Dog GetById(int id);
        bool Poster(Dog dog);
    }
}
