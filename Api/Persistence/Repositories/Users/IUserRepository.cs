using Api.Domain.Entities;

namespace Api.Persistence.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
}
