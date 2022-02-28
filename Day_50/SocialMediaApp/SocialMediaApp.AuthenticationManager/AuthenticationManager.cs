using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.AuthenticationManager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> ValidateCredentials(AuthCredentials credentials)
        {
            var user =  _userManager.Users.SingleOrDefault(x => x.UserName == credentials.UserName);

            return await _userManager.CheckPasswordAsync(user, credentials.Password) && user != null;   
        }
    }
}
