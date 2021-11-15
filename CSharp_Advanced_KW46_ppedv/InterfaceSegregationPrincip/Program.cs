using System;
using System.Collections.Generic;
using System.Linq.Expressions;


//Shortcut -> 1) STRG und .      -> zeigt Popup-Fenster an 2.) [Enter]best#tige dass using System.Collections.Generic; angelegt wird 
namespace InterfaceSegregationPrincip
{

    //https://github.com/SharpRepository/SharpRepository/blob/develop/SharpRepository.Repository/Traits/ICanAdd.cs
    class Program
    {
        static void Main(string[] args)
        {
            //wenn benutzer nur schreibrechte hat

            IReadRepository<Car> carReadRepository = new RepositoryBase<Car>();
            carReadRepository.GetAll();
            //carReadRepository.GetByStatement(s=>s.)
            carReadRepository.GetById(123);


            IRepository<Car> carRepository = new RepositoryBase<Car>();
            carRepository.GetAll();
            carRepository.Insert(new Car());
        }
    }

    internal class Car
    {
    }



    #region BadCode
    //Repository - Design Pattern dient zum Zugriff auf eine Datenbank-Tabelle 
    public interface IReadRepository<T>
    {

        IList<T> GetAll();
        IList<T> GetByStatement(Func<int, bool> predicate); //Where Klausel

        T GetById(int id); //einzelende Datentypen. 
    }

    public interface IRepository<T> : IReadRepository <T>
    {
        public void Insert(T item);

        public void Update(int Id, T modifiedItem);

        public void Delete(int Id);
    }

    public class RepositoryBase<T> : IRepository<T>
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetByStatement(Expression<Func<int, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, T modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Good Code

    public interface IOperationInsert <T> 
    {
        void Insert(T item);
    }

    public interface IOperationUpdate<T>
    {
        void Update(int id, T item);
    }

    public interface IOperationDelete<T>
    {
        void Delete(T item);
        void Delete(int id);
    }

    public interface IOperationGet<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }

    public class GoodRepository<T> : IOperationGet<T>, IOperationInsert<T>, IOperationUpdate<T>
    {
        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T item)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
