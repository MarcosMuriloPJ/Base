using Base.Domain.Entities;

namespace Base.Domain.InterfacesRepositories;

public interface IUserRepository
{
  Task<bool> GetExistByIdAsync(int id);
  Task<User?> GetByEmailAndPasswordAsync(string email, string pass);
}