using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
