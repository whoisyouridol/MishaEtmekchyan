using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonManagement.Models.Request;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
       
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(AccountCreateRequest user)
        {
            var result = await _userService.CreateAsync(user.Adapt<UserServiceModel>());

            return StatusCode((int)result.Item1, result.Item2);
        }
        [AllowAnonymous]
        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn(AccountLogInRequest user)
        {
            var result = await _userService.AuthenticationAsync(user.Username, user.Password, user.IsVerified);

            return StatusCode((int)result.Item1, result.Item2);
        }
        [Route("Confirm")]
        [HttpPost]
        public async Task<IActionResult> Confirm(string guid)
        {
            return Ok(await _userService.ConfirmUser(guid) ? "Confirmation ended successfully" :"Confirmation Failed" ) ;
        }

        [Route("UpdatePassword")]
        [HttpPost]
        public async Task <IActionResult> UpdatePassword(UpdatePasswordRequest user)
        {
            if (await _userService.ChangePassword(user.Adapt<UpdatePasswordServiceModel>()))
                return Ok("Password changed successfully");

            else return Conflict("Something gone wrong...");
        }

        [Authorize]
        [Route("ForAuthorized")]
        [HttpGet]
        public IActionResult ForAuthorized()
        {
            return Ok("Hey, you are authorized!");
        }
    }
}
