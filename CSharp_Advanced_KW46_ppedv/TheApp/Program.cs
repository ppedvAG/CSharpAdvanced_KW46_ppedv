using DAL.Data;
using DAL.Repository;
using System;

namespace TheApp
{
    class Program
    {
        static void Main(string[] args)
        {


            MovieRepository movieRepo = new MovieRepository();
            movieRepo.Insert(new DAL.Entities.Movie { Desciption = "Telefoniere nach Hause", Price = 2, Title = "ET" });


            //.... weitere Operationen

            movieRepo.Commit();
        }
    }
}
