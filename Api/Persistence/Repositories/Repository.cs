using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence.Repositories;

public class Repository<T>(AppDbContext db) : IRepository<T> where T : BaseEntity
{
    protected DbSet<T> Table => db.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct) =>
        await Table.FindAsync([id], ct);

    public Task<List<T>> GetAllAsync(CancellationToken ct) =>
        Table.AsNoTracking().ToListAsync(ct);

    public async Task AddAsync(T entity, CancellationToken ct) =>
        await Table.AddAsync(entity, ct);

    public void Update(T entity) => Table.Update(entity);

    public void Remove(T entity) => Table.Remove(entity);

    public Task<int> SaveChangesAsync(CancellationToken ct) => db.SaveChangesAsync(ct);
}
