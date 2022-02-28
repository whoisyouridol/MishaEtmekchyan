using AdminService.Abstractions;
using AdminService.ServiceModels;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateService.Abstractions;
using BackgroundJobService;
using BackgroundJobService.Abstractions;
using System.Linq;
using SocialMediaApp.Domain.Models;
using SocialMediaApp.Data;

namespace AdminService.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IValidateService _validateService;
        private readonly IAccountRepository _repository; 
        private readonly IBackgroundJobService _jobService;
        public AdminService(IValidateService validateService, IAccountRepository repository, IBackgroundJobService jobService) 
        {
            _validateService = validateService;
            _repository = repository;
            _jobService = jobService;
        }

        public async Task AddAccountsAsync(List<AccountServiceModel> accounts)
        {
            var validated = await _validateService.Validate(accounts.Adapt<List<ValidateAccountsServiceModel>>());

            if (validated)
            {
                await _repository.CreateAsync(accounts.Adapt<List<Account>>());

                await _jobService.SynchronizeAsync();
            }
        }
        public async Task DeleteAccountsAsync(List<AccountServiceModel> accounts)
        {
            await _repository.DeleteAccountsAsync(accounts.Adapt<List<Account>>());
        }
    }
}
