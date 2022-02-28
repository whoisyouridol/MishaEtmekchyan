using AdminService.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ValidateService.Abstractions;
using ValidateService.ServiceModels;

namespace ValidateService.Implementations
{
    public class ValidateService : IValidateService
    {
        public async Task<bool> Validate(List<ValidateAccountsServiceModel> inputedAccounts)
        {
            var uri = "https://api.twitter.com/2/users/by?usernames=" + string.Join(',', inputedAccounts.Select(x => x.Username));
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue
                ("Bearer", "AAAAAAAAAAAAAAAAAAAAAKcZZQEAAAAAE0oD18FOBaUJWi%2FfKOmri2odyII%3D5X1bfqfJGAm1bEgO978FGWL7sd2NMLGqx1vs04UddVJ2UwDgF2");
                var json = await (await client.GetAsync(uri)).Content.ReadAsStringAsync();

                var anonymousObj = new { Data = new List<ValidateAccountsServiceModel>() };

                var realAccounts = JsonConvert.DeserializeAnonymousType(json, anonymousObj);

                foreach (var item in inputedAccounts)
                {
                    if (!realAccounts.Data.Exists(x => x.Equals(item)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}