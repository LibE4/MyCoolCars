using MyCoolCars.Api.Models;
using MyCoolCars.Api.DAL;
using MyCoolCars.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCoolDogs.Api.Controllers
{
    public class DogController : ApiController
    {
        readonly IDogOperation _operation;

        public DogController()
        {
            _operation = new DogOperation();
        }

        public DogController(IDogOperation operation)
        {
            _operation = operation;
        }

        [HttpGet]
        [Route("api/dog")]
        public HttpResponseMessage getAllDogs()
        {
            var dogs = _operation.GetAll();

            if (dogs == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"No dog exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dogs);
        }
        [HttpGet]
        [Route("api/dog/{id}")]
        public HttpResponseMessage GetOneDog(int id)
        {
            var dog = _operation.GetById(id);

            if (dog == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The dog with an id of {id} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dog);
        }
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        [Route("api/newdog")]
        public HttpResponseMessage CreateDog()
        {
            var actionStatus = _operation.Poster(new Dog()
            {
                Name = "Ghost",
                Breed = "Bichon",
                Height = 0.7,
                Weight = 16
            });
            return Request.CreateResponse(HttpStatusCode.OK, actionStatus);
        }
    }
}
