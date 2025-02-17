using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;

namespace Base.Infrastructure.Persistence.Repositories;

public class TagRepository(BaseDbContext context) : GenericRepository<Tag>(context), ITagRepository
{
}
