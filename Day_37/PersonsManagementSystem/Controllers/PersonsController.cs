using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonsManagementSystem.Models.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UsersManagementService.Abstractions;
using UsersManagementService.Models;

namespace PersonsManagementSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IManagePeopleService _managePeopleService;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(IManagePeopleService managePeopleService, ILogger<PersonsController> logger)
        {
            _logger = logger;
            _managePeopleService = managePeopleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] AddPersonDTO person)
        {
            await _managePeopleService.AddAsync(person.Adapt<PersonModel>());
            _logger.LogInformation("New person added");
            return Ok("Person added successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _managePeopleService.GetPeopleAsync();
            _logger.LogInformation("All people data sent from api");
            return Json(result.Adapt<IEnumerable<GetPersonDTO>>());
        }
    }

}
