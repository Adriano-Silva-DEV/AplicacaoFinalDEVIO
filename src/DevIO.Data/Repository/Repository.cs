﻿using DevIO.Bussines.Interfaces;
using DevIO.Bussines.Models;
using DevIO.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDbContext db)
        {
            Db = db;
            Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            DbSet = Db.Set<TEntity>();

          }


        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

      
        public virtual async Task<TEntity> ObterPorId(Guid Id)
        {
           
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
           
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Adcionar(TEntity entity)
        {
            
            DbSet.Add(entity);
            await SaveChange();
           
        }

        public virtual async Task Atualizar(TEntity entity)
        {
           
            DbSet.Update(entity);
            
            await SaveChange();
           
        }

        public virtual async  Task Remover(Guid id)
        {
            //uma forma de fazer >> DbSet.Remove(await DbSet.FindAsync(id));
            DbSet.Remove(new TEntity { Id = id });
            await SaveChange();
        }

        public  async  Task<int> SaveChange()
        {
          
            return await Db.SaveChangesAsync();
           
        }

        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
}
