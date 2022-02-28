using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.AuthenticationManager
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateCredentials(AuthCredentials credentials);
    }
}
