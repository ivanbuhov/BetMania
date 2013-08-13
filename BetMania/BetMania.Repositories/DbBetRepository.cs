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
    public class DbBetRepository : IRepository<Bet>
    {
        private DbContext dbContext;
        private DbSet<Bet> entitySet;

        public DbBetRepository(DbContext dbContex)
        {
            this.dbContext = dbContex;
            this.entitySet = this.dbContext.Set<Bet>();
        }

        public Bet Add(Bet entity)
        {

            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Bet Update(Bet entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            var entry = this.dbContext.Entry<Bet>(entity);

            if (entry.State == EntityState.Detached)
            {
                Bet attachedEntity = this.entitySet.Find(entity.Id);
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
            //Bet deleteUser = new Bet
            // {
            //     Id = id
            // };

            //this.entitySet.Attach(deleteUser);
            //this.entitySet.Remove(deleteUser);
            //this.dbContext.SaveChanges();

            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Bet Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Bet> All()
        {
            return this.entitySet;
        }
    }
}
