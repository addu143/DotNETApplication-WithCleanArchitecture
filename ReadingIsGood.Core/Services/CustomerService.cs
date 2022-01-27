using Microsoft.AspNetCore.Identity;
using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerService(IRepository<Customer> repository,
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser applicationUser, string password)
        {
            return await _userManager.CheckPasswordAsync(applicationUser, password);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password)
        {
            return await _userManager.CreateAsync(applicationUser, password);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Customer> Add(Customer customer)
        {
            return await _repository.AddAsync(customer);
        }

        public async Task<List<Customer>> ListOfCustomers()
        {
            return await _repository.ListAsync();
        }
    }
}
