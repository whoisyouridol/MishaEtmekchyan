using ManageCarsService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManageCarsController : Controller
    {
        private static IManagable _service;
        public ManageCarsController(IManagable service)
        {
            _service = service;
        }

        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _service.GetAllCarsAsync());
        }

        [HttpGet("GetCar")]
        public async Task<IActionResult> GetCar(string name)
        {
            return Ok(await _service.GetCarByNameAsync(name));
        }

        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteCar(string name)
        {
            await _service.DeleteCarByNameAsync(name);
            return Ok("Car deleted successfully");
        }

        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            await _service.AddCarAsync(car);
            return Ok("Car added successfully");
        }

        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCarName(string oldName, string newName)
        {
            await _service.UpdateCarNameAsync(oldName, newName);
            return Ok("Car is updated successfully");
        }
    }
}