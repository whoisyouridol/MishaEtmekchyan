using SocialMediaApp.Data;
using SocialMediaApp.Data.Abstractions;
using SocialMediaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataEF.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IBaseRepository<Account> _repository;

        public AccountRepository(IBaseRepository<Account> repository)
        {
            _repository = repository;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Account> GetAsync(params object[] key)
        {
            return await GetAsync(key);
        }
        public async Task CreateAsync(List<Account> accounts)
        {
            await _repository.CreateAsync(accounts);
        }

        public async Task DeleteAccount(Account account)
        {
            await _repository.DeleteAsync(account);
        }

        public async Task DeleteAccountsAsync(List<Account> accounts)
        {
            await _repository.DeleteAsync(accounts);
        }
    }
}
