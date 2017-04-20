using MyCoolCars.Api.Interface;
using MyCoolCars.Api.Models;
using MyCoolCars.Api.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCoolTrucks.Api.Controllers
{
    public class TruckController : ApiController
    {
        readonly IOperation<Truck> _operation;

        public TruckController()
        {
            _operation = new TruckOperation();
        }

        public TruckController(IOperation<Truck> operation)
        {
            _operation = operation;
        }

        [HttpGet]
        [Route("api/truck")]
        public HttpResponseMessage getAllTrucks()
        {
            var trucks = _operation.GetAll();

            if (trucks == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"No truck exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, trucks);
        }
        [HttpGet]
        [Route("api/truck/{id}")]
        public HttpResponseMessage GetOneTruck(int id)
        {
            var truck = _operation.GetById(id);

            if (truck == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    $"The truck with an id of {id} does not exist");
            }

            return Request.CreateResponse(HttpStatusCode.OK, truck);
        }
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        [Route("api/newtruck")]
        public HttpResponseMessage CreateTruck()
        {
            var actionStatus = _operation.Poster(new Truck()
            {
                Make = "Ford",
                Model = "F250",
                Year = 1999
            });
            return Request.CreateResponse(HttpStatusCode.OK, actionStatus);
        }
    }
}
