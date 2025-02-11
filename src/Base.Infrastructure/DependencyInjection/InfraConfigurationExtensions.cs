using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Base.Domain.InterfacesRepositories;
using Base.Application.Services;
using Base.Infrastructure.Persistence;
using Base.Infrastructure.Persistence.Repositories;
using Base.Domain.Interfaces.Repositories;

namespace Base.Infrastructure.DependencyInjection;

public static class InfraConfigurationExtensions
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    // 1. Registra DbContext
    services.AddDbContext<BaseDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("Base")));

    // 2. Registra Serviços
    services.AddScoped<UserService>();
    services.AddScoped<NewsTagService>();
    services.AddScoped<TagService>();
    services.AddScoped<NewsService>();

    // 3. Registra Repositórios
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<INewsRepository, NewsRepository>();
    services.AddScoped<INewsTagRepository, NewsTagRepository>();
    services.AddScoped<ITagRepository, TagRepository>();

    return services;
  }
}