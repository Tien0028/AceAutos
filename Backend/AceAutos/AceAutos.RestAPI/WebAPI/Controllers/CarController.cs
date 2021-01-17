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
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        //UI Layer, part of presentation layer of CLEAN ARCHITECTURE.
        //A controller is responsible for controlling the way that a user interacts with an MVC application. 
        //A controller contains the flow control logic for an ASP.NET MVC application. 
        //A controller determines what response to send back to a user when a user makes a browser request.
        private readonly ICarService _carService;
        

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        //GET: api/Car
        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            //When link above is invoked in anyway, all cars are shown and displayed, after retrieving the cars from the lower stacks.
            //Upon selection, it gets cars from carservice.
            return _carService.GetCars();
            //Our Backend is heavily dependent on Inheritance, Polymorphism, and Dependency Injection 
            //allowing classes to inherit methods from other classes and use their methods to perform different tasks.
        }

        // GET api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            
            var pro = _carService.GetCar(id);
            if (pro == null)
            {
                return NotFound();
            }
            return new ObjectResult(pro);

        }

        // POST api/Car
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            
            _carService.Create(car);
            return CreatedAtRoute("Get", new { id = car.Id }, car);
        }

        // DELETE api/Car/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            try
            {
                return Ok(_carService.Delete(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car car)
        {
            try
            {
                return Ok(_carService.UpdateCar(id, car));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

 
    }
}
