using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbUserRoleRepository : IRepository<UserRole>
    {
        private DbContext dbContext;
        private DbSet<UserRole> entitySet;

        public DbUserRoleRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<UserRole>();
        }

        public UserRole Add(UserRole entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public UserRole Update(UserRole entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            this.entitySet.Attach(entity);
            this.dbContext.Entry(entity).State = System.Data.EntityState.Modified;
            this.dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            UserRole deleteUser = new UserRole
            {
                Id = id
            };

            this.entitySet.Attach(deleteUser);
            this.entitySet.Remove(deleteUser);
            this.dbContext.SaveChanges();
        }

        public UserRole Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<UserRole> All()
        {
            return this.entitySet;
        }
    }
}
