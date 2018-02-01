using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Entities
{
    public interface IUserService 
    {
        IEnumerable<User> GetAllData();
        IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate);
    }
}
