using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbMatchCategory : IRepository<MatchCategory>
    {
        private DbContext dbContext;
        private DbSet<MatchCategory> entitySet;

        public DbMatchCategory(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<MatchCategory>();
        }

        public MatchCategory Add(MatchCategory entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public MatchCategory Update(MatchCategory entity)
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
            MatchCategory deleteUser = new MatchCategory
            {
                Id = id
            };

            this.entitySet.Attach(deleteUser);
            this.entitySet.Remove(deleteUser);
            this.dbContext.SaveChanges();
        }

        public MatchCategory Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<MatchCategory> All()
        {
            return this.entitySet;
        }
    }
}
