using SimpleUserRegistration.Business.DTO;
using SimpleUserRegistration.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleUserRegistration.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            //if (userRepository == null)
            //    throw new ArgumentNullException("userRepository");
            //_userRepository = userRepository;
            _userRepository = new UserRepository();
            AutoMapper.AutoMapper.Initialise();
        }

        public IEnumerable<User> GetUsers()
        {            
            return _userRepository.GetUsers().Select(x => x.ToDTO());
        }

        public IEnumerable<User> GetUser(int id)
        {
            return _userRepository.GetUser(id).Select(x => x.ToDTO());
        }

        public bool AddUser(User user)
        {
            return _userRepository.AddUser(user.ToEntity());
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}
