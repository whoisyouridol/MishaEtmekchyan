using Mapster;
using PersonManagement.Data;
using PersonManagement.DataADO.Implementations;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailService;
using MailService.Models;
using PersonManagement.DataADO.Models;

namespace PersonManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMailService _mailService;

        public UserService(IUserRepository repo, IMailService mailService)
        {
            _mailService = mailService;
            _repo = repo;
        }


        public async Task<(Status, UserServiceModel)> AuthenticationAsync(string username, string password, bool verified)
        {
            var result = await _repo.GetAsync(username, password).ConfigureAwait(false);

            if (result == null || !verified)
                return (Status.Unauth, null);

            return (Status.Success, result.Adapt<UserServiceModel>());
        }

        public async Task<(Status, UserServiceModel)> CreateAsync(UserServiceModel user)
        {
            var exists = await _repo.Exists(user.Username);

            if (exists)
            {
                return (Status.AlreadyExists, null);
            }
            user.GUID = Guid.NewGuid().ToString();
            var result = await _repo.CreateAsync(user.Adapt<User>()).ConfigureAwait(false);

            await _mailService.SendMailAsync(new MailRequest()
            {
                Subject = "Email confirmation",
                Body = $"Hello, {user.Username}, follow this link to approve your registration : https://localhost:44338/api/account/confirm?token=" + user.GUID,
                ToEmail = user.Email
            });
            user.Password = "";
            return (Status.Success, user);
        }

        public async Task<bool> ConfirmUser(string guid)
        {
            if (!await _repo.ConfirmGuid(guid))
            {
                throw new InvalidOperationException();
            }
            else return true;
        }

        public async Task<bool> ChangePassword(UpdatePasswordServiceModel serviceModel)
        {
            var updated = await _repo.UpdatePasswordAsync(serviceModel.Adapt<UpdateUserModel>());
            if (updated.Item1)
            {
                var email = updated.Item2;
                await _mailService.SendMailAsync(new MailRequest()
                {
                    Body = $"Hey, {serviceModel.UserName}, your password was changed.",
                    Subject = "Password changed",
                    ToEmail = email
                });
                return true;
            }
            return false;
        }
    }
}
