using AdminService.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Abstractions
{
    public interface IAdminService
    {
        Task AddAccountsAsync(List<AccountServiceModel> accounts);
        Task DeleteAccountsAsync(List<AccountServiceModel> addAccountsServiceModels);
    }
}
