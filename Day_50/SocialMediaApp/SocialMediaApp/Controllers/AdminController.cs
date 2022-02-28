using AdminService.Abstractions;
using AdminService.ServiceModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.RequestModels;
using System.Collections.Generic;
using System;
using WorkWithDbService;
using System.Threading.Tasks;
using SocialMediaApp.AuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAuthenticationManager _authManager;
        public AdminController(IAdminService adminService, IAuthenticationManager authManager)
        {
            _adminService = adminService;
            _authManager = authManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthCredentials credentials)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (!await _authManager.ValidateCredentials(credentials))
            {
                return Unauthorized();
            }
            return Ok("Authorized");
        }

        [HttpGet("testauth")]
        [Authorize]
        public async Task<IActionResult> TestAuth()
        {
            return Ok("Inside method for authorized guys");
        }
        [HttpPost]
        public async Task<IActionResult> AddAccounts(List<AccountRequestModel> accounts)
        {
            if (accounts != null)
                await _adminService.AddAccountsAsync(accounts.Adapt<List<AccountServiceModel>>());
            else throw new ArgumentNullException();
            return Ok("Validated and added to DB");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(List<AccountRequestModel> accounts)
        {
            if (accounts != null)
                await _adminService.DeleteAccountsAsync(accounts.Adapt<List<AccountServiceModel>>());
            else throw new ArgumentNullException();
            return Ok("Deleted successfully");
        }
    }
}