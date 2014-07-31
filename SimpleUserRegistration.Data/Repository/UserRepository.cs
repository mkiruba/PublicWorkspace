using NHibernate;
using NHibernate.Linq;
using SimpleUserRegistration.Data.DataEntities;
using SimpleUserRegistration.Data.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleUserRegistration.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository()
        {
            //if (session == null)
            //    throw new ArgumentNullException("session");
            //_session = session;
            _session = NHibernateHelper.SessionFactory.OpenSession();
        }
        public IEnumerable<UserEntity> GetUsers()
        {
            return _session.Query<UserEntity>();
        }

        public IEnumerable<UserEntity> GetUser(int id)
        {
            return _session.Query<UserEntity>().Where(x => x.Id == id);
        }

        public bool AddUser(UserEntity user)
        {
            //if (_session.Get<UserEntity>(user.Id) != null)
            //    throw new ApplicationException("Duplicate User");
            
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(user);
                transaction.Commit();
            }            
            return true;
        }

        public bool DeleteUser(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var toDelete = GetUser(id);
                if (toDelete == null)
                    return false;
                foreach(var d in toDelete)
                    _session.Delete(d);
                transaction.Commit();
            }
            return true;
        }

    }
}
