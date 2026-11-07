using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence.Repositories.Products;

public sealed class ProductRepository(AppDbContext db) : Repository<Product>(db), IProductRepository
{
    public Task<List<Product>> GetByStoreIdAsync(Guid storeId, CancellationToken ct) =>
        Table.AsNoTracking().Where(p => p.StoreId == storeId).ToListAsync(ct);
}
