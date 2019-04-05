using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Services;
using Factories;
using Autofac;
using Repositories;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;
using LinqKit;


namespace UnitOfWorkSample02
{
    /// <summary>
    /// RepositoryパターンでのPersistent Frameworkの隠蔽
    /// Unit of workパターンでのトランザクション管理のサンプル
    /// 
    /// DIコンテナとしてAutofacを利用、CastleプロジェクトのDynamicProxyを
    /// 使用して、処理ログを出力
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //DIコンテナのインスタンス生成
            var builder = new ContainerBuilder();

            builder.RegisterType<ConcreteUnitOfWorkFactory>()
                .As<UnitOfWorkAbstractFactory>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(TraceInterceptor)); 

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TraceInterceptor));

            builder.RegisterType<TraceInterceptor>();

            var container = builder.Build();

            //IUserServiceに対して登録されたクラスでインスタンス生成
            var userService = container.Resolve<IUserService>();

            //ユーザー一覧の取得
            var allUsers = userService.GetAllData();

            //ユーザー一覧の出力
            foreach (var user in allUsers)
            {
                Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}");
            }

            Console.Read();
        }

        /// <summary>
        /// トレースログの出力
        /// コンテナに登録されたクラスで処理が実行した際に
        /// 出力する。
        /// </summary>
        private class TraceInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                var sw = new System.Diagnostics.Stopwatch();

                sw.Start();
                System.Console.WriteLine("==Trace Start== メソッドを開始します::" + invocation.Method.Name);
                var s = "";
                foreach (var o in invocation.Arguments)
                {
                    s += "[" + o + "]";
                }
                System.Console.WriteLine("メソッド呼び出しの引数::" + s);
                invocation.Proceed();
                sw.Stop();
                System.Console.WriteLine("==Trace End== メソッド呼び出しが正常終了::" + invocation.Method.Name + "処理時間：" + sw.Elapsed);
            }
        }
    }


}
