using Core.Models;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}
