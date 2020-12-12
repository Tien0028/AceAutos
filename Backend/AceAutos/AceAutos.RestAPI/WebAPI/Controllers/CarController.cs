using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceAutos.Core.ApplicationService;
using AceAutos.Core.DomainService;
using AceAutos.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarRepository _carRepo;

        public CarController(ICarService carService, ICarRepository carRepo)
        {
            _carService = carService;
            _carRepo = carRepo;
        }

        //GET: api/Car
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _carService.GetCars();
        }

        // GET api/Car/5
        //[Authorize(Roles = "Adminstrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            
            var pro = _carRepo.GetCar(id);
            if (pro == null)
            {
                return NotFound();
            }
            return new ObjectResult(pro);

        }

        // POST api/Car
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            _carRepo.AddCar(car);

            return CreatedAtRoute("Get", new { id = car.Id }, car);
        }

        // DELETE api/ApiWithActions/5
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //return _carService.Delete(id);
            var pro = _carRepo.GetCar(id);
            if (pro == null)
            {
                return NotFound();
            }
            _carRepo.RemoveCar(id);
            return new NoContentResult();
        }

        ////[Authorize(Roles = "Administrator")]
        //[HttpDelete("{id}")]
        //public IActionResult DeleteAll(long id)
        //{
        //    //return _carService.Delete(id);
        //    var pro = _carRepo.GetAllCars();
        //    if (pro == null)
        //    {
        //        return NotFound();
        //    }
        //    _carRepo.RemoveCar(id);
        //    return new NoContentResult();
        //}

    }
}
