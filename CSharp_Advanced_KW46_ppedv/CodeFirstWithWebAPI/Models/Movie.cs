using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstWithWebAPI.Models
{
    public class Movie
    {
        public int Id { get; set; } 

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public float IMDBRating { get; set; }

    }
}
