using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Traits
{
    public interface IDeleteCommand<TEntity, TKey> where TEntity : class
    {
        void Delete(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        void Delete(TKey id);
    }
}
