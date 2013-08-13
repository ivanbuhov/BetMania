using BetMania.Database;
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
    public class DbMatchCategory : IRepository<MatchCategory>
    {
        private DbContext dbContext;
        private DbSet<MatchCategory> entitySet;
        private DbSet<Match> entityMatchSet;

        public DbMatchCategory(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<MatchCategory>();
            this.entityMatchSet = this.dbContext.Set<Match>();
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

            var entry = this.dbContext.Entry<MatchCategory>(entity);

            if (entry.State == EntityState.Detached)
            {
                MatchCategory attachedEntity = this.entitySet.Find(entity.Id);
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

        public MatchCategory Get(int id)
        {
            var matchCat= this.entitySet.Find(id);

            matchCat.Matchs = this.entityMatchSet.Where(x => x.MatchCategory.Id == id);
            return matchCat;
        }

        public IQueryable<MatchCategory> All()
        {
            return this.entitySet;
        }
    }
}
