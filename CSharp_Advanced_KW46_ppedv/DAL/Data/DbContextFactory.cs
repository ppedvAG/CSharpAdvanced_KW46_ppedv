using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public static class DbContextFactory
    {
        private static MovieDbContext movieDBContext = null;

        static DbContextFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MovieABCDatabase;Integrated Security=true;");

            movieDBContext = new MovieDbContext(optionsBuilder.Options);
        }

        public static MovieDbContext GeoDBContextInstance
        {
            get { return movieDBContext; }
        }
    }
}
