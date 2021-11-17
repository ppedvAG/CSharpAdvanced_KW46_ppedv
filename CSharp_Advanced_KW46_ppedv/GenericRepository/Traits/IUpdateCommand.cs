using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Traits
{
    public interface IUpdateCommand<TEntity, TKey> where TEntity : class
    {
        void Update(TEntity modifiedEntity);
    }
}
