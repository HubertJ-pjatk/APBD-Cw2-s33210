using System.Collections.Generic;

namespace DefaultNamespace;

public class UserService : IUserService
{
    private readonly List<User> usersList = new List<User>();

    public void AddUser(User user)
    {
        usersList.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return usersList;
    }
}