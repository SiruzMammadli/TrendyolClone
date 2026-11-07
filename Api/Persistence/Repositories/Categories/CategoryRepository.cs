using Api.Domain.Entities;

namespace Api.Persistence.Repositories.Categories;

public sealed class CategoryRepository(AppDbContext db) : Repository<Category>(db), ICategoryRepository
{
}
