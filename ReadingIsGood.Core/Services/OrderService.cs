using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
        {
            return _repository.AddAsync(order, cancellationToken);
        }

        public Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
        {
            return _repository.UpdateAsync(order, cancellationToken);
        }

        public Task DeleteAsync(Order order, CancellationToken cancellationToken = default)
        {
            return _repository.DeleteAsync(order, cancellationToken);
        }

        public Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _repository.GetByIdAsync(id, cancellationToken);
        }

        public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _repository.ListAsync(cancellationToken);
        }
    }
}
