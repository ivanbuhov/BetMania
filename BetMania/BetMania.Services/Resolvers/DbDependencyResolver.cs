using BetMania.Database;
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

        public static DbUserRepository userRepository = 
            new DbUserRepository(betManiaContext);

        public static IRepository<Bet> betRepository =
           new DbBetRepository(betManiaContext);

        public static IRepository<Match> matchRepository =
            new DbMatchesRepository(betManiaContext);


        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(userRepository);
            }

            if (serviceType == typeof(BetsController))
            {
                return new BetsController(betRepository);
            }

            if (serviceType == typeof(MatchsController))
            {
                return new MatchsController(matchRepository);
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