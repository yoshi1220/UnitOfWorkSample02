using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Factories
{
    public abstract class UnitOfWorkAbstractFactory
    {
        public abstract IUnitOfWork GetUnitOfWorkInstance();
    }
}
