using SimpleUserRegistration.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUserRegistration.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetUsers();
        IEnumerable<UserEntity> GetUser(int id);
        bool AddUser(UserEntity user);
        bool DeleteUser(int id);
    }
}
