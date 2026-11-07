using Api.Domain.Entities;

namespace Api.Persistence.Repositories.Stores;

public sealed class StoreRepository(AppDbContext db) : Repository<Store>(db), IStoreRepository
{
}
