using BetMania.Models;
using System;
using System.Collections.Generic;
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

            this.entitySet.Attach(entity);
            this.dbContext.Entry(entity).State = System.Data.EntityState.Modified;
            this.dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            Bet deleteUser = new Bet
             {
                 Id = id
             };

            this.entitySet.Attach(deleteUser);
            this.entitySet.Remove(deleteUser);
            this.dbContext.SaveChanges();
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
