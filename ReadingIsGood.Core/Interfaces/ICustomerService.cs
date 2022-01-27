using Microsoft.AspNetCore.Identity;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<ApplicationUser> FindByEmailAsync(string email);

        Task<ApplicationUser> FindByNameAsync(string userName);

        Task<bool> CheckPasswordAsync(ApplicationUser applicationUser, string password);

        Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password);

        Task<Customer> Add(Customer customer);

        Task<List<Customer>> ListOfCustomers();
    }
}
