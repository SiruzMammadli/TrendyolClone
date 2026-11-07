using Api.Domain.Entities;

namespace Api.Persistence.Repositories.Orders;

public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetByBuyerIdAsync(Guid buyerId, CancellationToken ct);
}
