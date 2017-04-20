using MyCoolCars.Api.DAL;
using MyCoolCars.Api.Interface;
using MyCoolCars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCoolCars.Api.Controllers
{
    public class CarController : ApiController
    {
        readonly ICarOperation _operation;

        public CarController()
        {
            _operation = new CarOperation();
        }

        public CarController(ICarOperation operation)
        {
            _operation = operation;
        }

        [HttpGet]
        [Route("api/car")]
        public HttpResponseMessage getAllCars()
        {
            var cars = _operation.GetAll();

            if (cars == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"No car exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, cars);
        }
        [HttpGet]
        [Route("api/car/{id}")]
        public HttpResponseMessage GetOneCar(int id)
        {
            var car = _operation.GetById(id);

            if (car == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The car with an id of {id} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        [Route("api/newcar")]
        public HttpResponseMessage CreateCar() {
            var actionStatus = _operation.Poster(new Car()
            {
                Make = "Ford",
                Model = "Sedan",
                Year = 1999
            });
            return Request.CreateResponse(HttpStatusCode.OK, actionStatus);
        }
    }
}
