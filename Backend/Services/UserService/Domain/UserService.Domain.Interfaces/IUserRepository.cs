using UserService.Domain.Core;

namespace UserService.Domain.Interfaces;

public interface IUserRepository
{
    User? GetUser(int id);
    IEnumerable<User> GetUsers();
    void Create(User user);
    void Update(User user);
    void Delete(int id);
    void Save();
}