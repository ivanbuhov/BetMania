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

            this.entitySet.Attach(entity);
            this.dbContext.Entry(entity).State = System.Data.EntityState.Modified;
            this.dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            Match deleteUser = new Match
            {
                Id = id
            };
            
           this.entitySet.Attach(deleteUser);
           this.entitySet.Remove(deleteUser);
           this.dbContext.SaveChanges();
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
