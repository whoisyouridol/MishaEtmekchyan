using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Models.DTO;
using PersonManagement.Models.Request;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace PersonManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<List<PersonDTO>> GetAll()
        {
            Debug.WriteLine(HttpContext.User.Identity.Name);

            var result = await _service.GetAllAsync();

            return result.Adapt<List<PersonDTO>>();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);

            if (result.status == Status.Success)
                return Ok(result.Item2.Adapt<PersonDTO>());

            return StatusCode((int)result.status);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonRequest request)
        {
            var serviceModel = request.Adapt<PersonServiceModel>();

            var entity = await _service.CreateAsync(serviceModel);

            if (entity.status == Status.Success)
                return Ok(entity.id);

            return StatusCode((int)entity.status);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PersonPutRequest request)
        {
            var personServiceModel = request.Adapt<PersonServiceModel>();

            var result = await _service.UpdateAsync(personServiceModel);

            return StatusCode((int)result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return StatusCode((int)result);
        }
    }
}
