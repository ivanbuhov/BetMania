using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbBetTypeRepository :IRepository<BetType>
    {
        private DbContext dbContext;
        private DbSet<BetType> entitySet;

        public DbBetTypeRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<BetType>();
        }

        public BetType Add(BetType entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public BetType Update(BetType entity)
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
            BetType deleteUser = new BetType
            {
                Id = id
            };

            this.entitySet.Attach(deleteUser);
            this.entitySet.Remove(deleteUser);
            this.dbContext.SaveChanges();
        }

        public BetType Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<BetType> All()
        {
            return this.entitySet;
        }
    }
}
