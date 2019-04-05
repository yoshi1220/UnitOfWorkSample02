using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;

namespace Factories
{
    /// <summary>
    /// Entity Framework Coreでデータベースアクセスするための
    /// UnitOfWorkのインスタンスを生成する。
    /// </summary>
    public class ConcreteUnitOfWorkFactory : UnitOfWorkAbstractFactory
    {
        public override IUnitOfWork GetUnitOfWorkInstance()
        {
            return new UnitOfWork(new PlutoContext());
        }
    }
}
