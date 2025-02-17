using Base.Domain.Entities;

namespace Base.Domain.Interfaces.Repositories;

public interface IUserRepository
{
  Task<bool> GetExistByIdAsync(int id);
  Task<User?> GetByEmailAndPasswordAsync(string email, string pass);
}