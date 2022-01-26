using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
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
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;

        }

        public async Task<Customer> Add()
        {
            return await _repository.AddAsync(new Customer() { Name = "Mohsin1" });
            
        }
    }
}
