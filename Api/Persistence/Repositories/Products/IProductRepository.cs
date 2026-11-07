using Api.Domain.Entities;

namespace Api.Persistence.Repositories.Products;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> GetByStoreIdAsync(Guid storeId, CancellationToken ct);
}
