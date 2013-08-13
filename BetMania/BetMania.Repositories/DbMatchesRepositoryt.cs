using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetMania.Repositories
{
    public class DbMatchesRepositoryt : IRepository<Match>
    {

        private DbContext dbContext;
        private DbSet<Match> entitySet;

        public DbMatchesRepositoryt(DbContext dbContex)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContex;
            this.entitySet = this.dbContext.Set<Match>();
        }


        public Match Add(Match entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Match Update(Match entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var entry = this.dbContext.Entry<Match>(entity);

            if (entry.State == EntityState.Detached)
            {
                User attachedEntity = this.entitySet.Find(entity.Id);
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

            dbContextUsers.SaveChanges();

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

        public Match Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Match> All()
        {
            return this.entitySet;
        }
    }
}
