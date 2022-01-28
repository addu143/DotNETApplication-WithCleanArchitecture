using Microsoft.AspNetCore.Identity;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<ApplicationUser> FindByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<ApplicationUser> FindByNameAsync(string userName);

        Task<bool> CheckPasswordAsync(ApplicationUser applicationUser, string password);

        Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password);

        Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken = default);

        Task<List<Customer>> ListOfCustomersAsync(CancellationToken cancellationToken = default);
    }
}
