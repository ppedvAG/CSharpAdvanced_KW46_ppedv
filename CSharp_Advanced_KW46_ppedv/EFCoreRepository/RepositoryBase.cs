using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepository
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class
    {

        private DbContext _dbContext = null;
        private DbSet<TEntity> _dbSet = null;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> DbSet { get => _dbSet; set => _dbSet = value; }
        public virtual void Commit() => _dbContext.SaveChanges();
        public virtual int Count() => DbSet.Count();
        public virtual int Count(Expression<Func<TEntity, bool>> predicate) => DbSet.Count(predicate);
        
        [Obsolete]
        public void Delete(Expression<Func<TEntity, bool>> predicate) => throw new NotSupportedException();
        public virtual void Delete(TEntity entity) => DbSet.Remove(entity);
        public virtual void Delete(TKey id)
        {
            TEntity current = GetById(id);
            Delete(current);
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate) => DbSet.Single(predicate);
        public virtual IList<TEntity> GetAll() => DbSet.ToList();
        public virtual TEntity GetById(TKey id) => DbSet.Find(id);
        public virtual void Insert(TEntity entity) => DbSet.Add(entity);
        public virtual void Update(TEntity modifiedEntity) => DbSet.Update(modifiedEntity);
        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate).AsQueryable();
       
    }

    //public interface SampleInterfaceForBasePoco<TKey>
    //{
    //    TKey Id { get; set; } 
    //}

    //public class Employee : SampleInterfaceForBasePoco<int>
    //{
    //    public int Id { get; set; }
    //}

}
