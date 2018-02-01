using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;
using Factories;
using System.Linq.Expressions;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWorkAbstractFactory _factory;

        public UserService(UnitOfWorkAbstractFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<User> GetAllData()
        {
            using (var uow = _factory.GetUnitOfWorkInstance())
            {
                return uow.Users.GetAll();
            }
        }

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            using (var uow = _factory.GetUnitOfWorkInstance())
            {
                return uow.Users.Find(predicate);
            }
        }
    }
}
