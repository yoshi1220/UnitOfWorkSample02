using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Factories
{
    /// <summary>
    /// UnitOfWorkのインスタンス生成用の抽象クラス
    /// ユニットテスト時にモック用のインスタンスを生成出来るように
    /// するため、Factoryにしておく。
    /// </summary>
    public abstract class UnitOfWorkAbstractFactory
    {
        public abstract IUnitOfWork GetUnitOfWorkInstance();
    }
}
