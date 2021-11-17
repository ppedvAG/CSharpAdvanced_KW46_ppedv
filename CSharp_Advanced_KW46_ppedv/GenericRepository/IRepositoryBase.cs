using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Traits;

namespace GenericRepository
{
    public interface IRepositoryBase<TEntity, TKey> 
        : IReadCommand<TEntity, TKey>, 
          ICreateCommand<TEntity>,
          IUpdateCommand<TEntity, TKey>,
          IDeleteCommand<TEntity, TKey> where TEntity : class 
    {
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);

        void Commit(); //Comit -> UOW - Pattern, kann auch anders implementiert werden 
    }
}
