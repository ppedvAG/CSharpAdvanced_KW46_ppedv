using DAL.Data;
using DAL.Entities;
using EFCoreRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MovieRepository : RepositoryBase<Movie,int>
    {

        public MovieRepository()
            :base(DbContextFactory.GeoDBContextInstance)
        {

        } 


        public override void Commit()
        {
            base.Commit();
        }

        public override int Count()
        {
            return base.Count();
        }

        public override int Count(Expression<Func<Movie, bool>> predicate)
        {
            return base.Count(predicate);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
        }


        public override void Delete(Movie entity)
        {
            base.Delete(entity);
        }

        public override Movie Get(Expression<Func<Movie, bool>> predicate)
        {
            return base.Get(predicate);
        }

        public override IList<Movie> GetAll()
        {
            return base.GetAll();
        }

        public override Movie GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Insert(Movie entity)
        {
            base.Insert(entity);
        }

        public override void Update(Movie modifiedEntity)
        {
            base.Update(modifiedEntity);
        }

        public override IQueryable<Movie> Where(Expression<Func<Movie, bool>> predicate)
        {
            return base.Where(predicate);
        }
        
    }
}
