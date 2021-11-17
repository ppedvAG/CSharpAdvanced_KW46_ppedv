using CodeFirstWithWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstWithWebAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }

    //Was ist ein Repository-Pattern?
    //Ist ein Muster (Klasse), die sich um das Manipulieren einer Tabelle kümmert. (Create, Update, Delete, Read)
}
