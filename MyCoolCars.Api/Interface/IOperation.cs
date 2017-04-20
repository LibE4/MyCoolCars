using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolCars.Api.Interface
{
    public interface IOperation<T>
    {

        List<T> GetAll();
        T GetById(int id);
        bool Poster(T t);
    }
}
