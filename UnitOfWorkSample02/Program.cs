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
    class Program
    {
        static void Main(string[] args)
        {

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

            var userService = container.Resolve<IUserService>();
            var allUsers = userService.GetAllData();

            foreach (var user in allUsers)
            {
                Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}");
            }

            Console.Read();
        }

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
