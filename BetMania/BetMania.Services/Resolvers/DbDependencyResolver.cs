﻿using BetMania.Database;
using BetMania.Models;
using BetMania.Repositories;
using BetMania.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace BetMania.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext betManiaContext = new BetManiaContext();

        public static IRepository<User> userRepository = 
            new DbUserRepository(betManiaContext);


        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UserController))
            {
                return new UserController(userRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}