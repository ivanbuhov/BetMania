using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbBetTypeRepository : IRepository<BetType>
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
            var entry = this.dbContext.Entry<BetType>(entity);

            if (entry.State == EntityState.Detached)
            {
                BetType attachedEntity = this.entitySet.Find(entity.Id);
                if (attachedEntity != null)
                {
                    var attachedEntry = this.dbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

            dbContext.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
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
