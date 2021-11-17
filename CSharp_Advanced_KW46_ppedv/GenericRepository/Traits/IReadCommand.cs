using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Traits
{
    public interface IReadCommand<TEntity, TKey> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        TEntity GetById(TKey id);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();
    }
}
