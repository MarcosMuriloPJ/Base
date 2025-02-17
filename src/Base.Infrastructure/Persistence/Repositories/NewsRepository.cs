using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;

namespace Base.Infrastructure.Persistence.Repositories;

public class NewsRepository(BaseDbContext context) : GenericRepository<News>(context), INewsRepository
{
}