using AceAutos.Core.ApplicationService;
using AceAutos.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/cartype")]
    public class CarTypeController : Controller
    {
        private readonly ICarTypeService _carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarType>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_carTypeService.GetFilteredCarType(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CarType> Get(int id)
        {
            if (id < 1) return BadRequest("ID must be greater than 0");
            if (_carTypeService.GetCarTypeWithId(id) == null) return BadRequest("Could not find Car Type with that ID");
            return _carTypeService.GetCarTypeWithId(id);
        }

        [HttpPost]
        public ActionResult<CarType> Post([FromBody] CarType carType)
        {
            try
            {
                return Ok(_carTypeService.CreateCarType(carType));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CarType> Put(int id, [FromBody] CarType carType)
        {
            if (id < 1 || id != carType.Id) return BadRequest("Parameter ID and Car Type ID does not match");

            return Ok(_carTypeService.UpdateCarType(carType));
        }

        [HttpDelete("{id}")]
        public ActionResult<CarType> Delete(int id)
        {
            var prod = _carTypeService.RemoveCarType(id);
            if (prod == null) return StatusCode(404, "Did not find Car Type with ID " + id);
            return Ok($"Car Type with Id: {id} has been deleted");
        }
    }
}