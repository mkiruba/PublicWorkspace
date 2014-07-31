using SimpleUserRegistration.Business.DTO;
using System.Collections.Generic;

namespace SimpleUserRegistration.Business
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUser(int id);
        bool AddUser(User user);
        bool DeleteUser(int id);
    }
}
