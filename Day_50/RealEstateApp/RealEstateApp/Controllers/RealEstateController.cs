using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using System.Threading.Tasks;

namespace RealEstateApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RealEstateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;   
        public RealEstateController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult>Register([FromBody]CreateRequestModel model )
        {
           await _userManager.CreateAsync(new IdentityUser { UserName = model.Login, PasswordHash = model.Password});
            return Ok("User created");
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public  async Task<IActionResult> LogIn([FromBody]string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            await  _signInManager.SignInAsync( await _userManager.FindByEmailAsync(id), isPersistent: false);
            return Ok();
        }
    }
}
