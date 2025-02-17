using Base.Domain.Interfaces.Repositories;

namespace Base.Application.Services;

public class UserService(IUserRepository repository)
{
  private readonly IUserRepository repo = repository;

  public async Task<int?> AuthenticateAsync(string email, string password)
  {
    var user = await repo.GetByEmailAndPasswordAsync(email, password);
    return user?.Id;
  }

  public async Task<bool> GetExistByIdAsync(int Id)
  {
    return await repo.GetExistByIdAsync(Id);
  }

}