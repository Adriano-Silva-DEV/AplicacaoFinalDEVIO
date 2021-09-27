using DevIO.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bussines.Interfaces
{
    //IDisposable faça dispose para liberar memoria
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
       public  Task Adcionar(TEntity entity);

        public Task<TEntity> ObterPorId(Guid Id);

        public Task<List<TEntity>> ObterTodos();

        public Task Atualizar(TEntity entity);

        public Task Remover(Guid id);

        public Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate );

        public Task<int> SaveChange();
    }
}
