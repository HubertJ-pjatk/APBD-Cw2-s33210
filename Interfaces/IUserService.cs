using System.Collections.Generic;

namespace DefaultNamespace;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetAllUsers();
}