using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaApp.Data
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();

        Task<Account> GetAsync(params object[] key);

        Task CreateAsync(List<Account> accounts);

        Task DeleteAccount(Account entity);

        Task DeleteAccountsAsync(List<Account> entity);

    }
}
