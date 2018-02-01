using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;

namespace Factories
{
    public class ConcreteUnitOfWorkFactory : UnitOfWorkAbstractFactory
    {
        public override IUnitOfWork GetUnitOfWorkInstance()
        {
            return new UnitOfWork(new PlutoContext());
        }
    }
}
