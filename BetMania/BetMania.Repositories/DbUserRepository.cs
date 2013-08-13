using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbUserRepository : IRepository<User>
    {
        private DbContext dbContextUsers;
        private DbSet<User> entitySetUser;

        public DbUserRepository(DbContext dbContext)
        {
             if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContextUsers = dbContext;
            this.entitySetUser = this.dbContextUsers.Set<User>();
        }

        public User Add(User entity)
        {
            this.entitySetUser.Add(entity);
            this.dbContextUsers.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
 
            this.entitySetUser.Attach(entity);
            this.dbContextUsers.Entry(entity).State = System.Data.EntityState.Modified;
            dbContextUsers.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            User deleteUser = new User
            {
                Id = id
            };

           this.entitySetUser.Attach(deleteUser);
           this.entitySetUser.Remove(deleteUser);
           this.dbContextUsers.SaveChanges();
        }

        public User Get(int id)
        {
            return this.entitySetUser.Find(id);
        }

        public IQueryable<User> All()
        {
            return this.entitySetUser;
        }
    }
}
