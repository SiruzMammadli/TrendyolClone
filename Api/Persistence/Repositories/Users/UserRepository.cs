using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence.Repositories.Users;

public sealed class UserRepository(AppDbContext db) : Repository<User>(db), IUserRepository
{
    public Task<User?> GetByEmailAsync(string email, CancellationToken ct) =>
        Table.FirstOrDefaultAsync(u => u.Email == email, ct);
}
