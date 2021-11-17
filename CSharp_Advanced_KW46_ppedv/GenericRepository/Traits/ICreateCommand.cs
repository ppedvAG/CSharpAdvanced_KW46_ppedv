using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Traits
{
    public interface ICreateCommand<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
    }
}
