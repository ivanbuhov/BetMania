﻿using BetMania.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

            var entry = this.dbContext.Entry<UserRole>(entity);

            if (entry.State == EntityState.Detached)
            {
                UserRole attachedEntity = this.entitySet.Find(entity.Id);
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
