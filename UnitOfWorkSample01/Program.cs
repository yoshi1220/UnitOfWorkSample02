using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Services;

namespace UnitOfWorkSample01
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IUserService _userService = new UserService();

            var allUsers = _userService.GetAllData();

            foreach(var user in allUsers)
            {
                Console.WriteLine($"UserId: {user.UserId}, UserName: {user.UserName}");
            }

            Console.Read();
        }
    }
}
