using PersonManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Services.Abstractions
{
    public interface IUserService
    {
        Task<(Status, UserServiceModel)> AuthenticationAsync(string username, string password,bool verified);

        Task<(Status, UserServiceModel)> CreateAsync(UserServiceModel user);
        Task<bool> ConfirmUser(string guid);

        Task<bool> ChangePassword(UpdatePasswordServiceModel serviceModel);
    }
}
