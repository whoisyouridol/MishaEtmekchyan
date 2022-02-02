using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using PersonManagement.Services.Models.@enum;
using PersonManagement.Web.Infrastracture.Localizations;
using PersonManagement.Web.Infrastracture.Validators;
using PersonManagement.Web.Models.DTO;
using PersonManagement.Web.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Web.Controllers
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

        [HttpGet]
        public async Task<List<PersonDTO>> GetAll()
        {
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
        public async Task<IActionResult> Post(CreatePersonRequest request)
        {
            var serviceModel = request.Adapt<PersonServiceModel>();

            var entity = await _service.CreatAsync(serviceModel);

            if (entity.status == Status.Success)
                return Ok(entity.id);

            return StatusCode((int)entity.status);
        }

        [HttpPost]
        public async Task<IActionResult> Put(PutPersonRequest request)
        {
            var serviceModel = request.Adapt<PersonServiceModel>();

            var result = await _service.UpdateAsync(serviceModel);

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
