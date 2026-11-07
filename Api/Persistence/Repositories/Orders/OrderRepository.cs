using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence.Repositories.Orders;

public sealed class OrderRepository(AppDbContext db) : Repository<Order>(db), IOrderRepository
{
    public Task<List<Order>> GetByBuyerIdAsync(Guid buyerId, CancellationToken ct) =>
        Table.AsNoTracking().Where(o => o.BuyerId == buyerId).ToListAsync(ct);
}
