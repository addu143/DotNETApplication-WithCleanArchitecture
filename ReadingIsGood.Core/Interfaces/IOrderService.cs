using ReadingIsGood.Core.DBEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default);
        Task UpdateAsync(Order order, CancellationToken cancellationToken = default);
        Task DeleteAsync(Order order, CancellationToken cancellationToken = default);
        Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
