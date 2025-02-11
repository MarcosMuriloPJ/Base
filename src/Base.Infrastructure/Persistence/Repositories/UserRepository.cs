using Base.Domain.Entities;
using Base.Domain.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Infrastructure.Persistence.Repositories;

public class UserRepository(ILogger<UserRepository> logger, BaseDbContext context) : IUserRepository
{
  private readonly ILogger<UserRepository> _logger = logger;
  private readonly BaseDbContext _context = context;

  public async Task<bool> GetExistByIdAsync(int id)
  {
    try
    {
      return await _context.Users.AnyAsync(u => u.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao validar o usuário com ID {Id}", id);
      throw new Exception("O usuário não pode ser validado, favor contate o administrador para mais informações.");
    }
  }

  public async Task<User?> GetByEmailAndPasswordAsync(string email, string pass)
  {
    try
    {
      return await _context.Users
          .FirstOrDefaultAsync(u => u.Email == email && u.Pass == pass);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Erro ao validar o usuário com E-mail {Email}", email);
      throw new Exception("O usuário não pode ser validado, favor contate o administrador para mais informações.");
    }
  }

}