using AdminService.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ValidateService.Abstractions
{
    public interface IValidateService
    {
        Task<bool> Validate(List<ValidateAccountsServiceModel> accounts);
    }
}
