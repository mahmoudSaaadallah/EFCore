using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }

        // Navigation property for many-to-many relationship
        // So this navigaion told the EFC that this model has a relation with the Actor model and the
        //   relation is many form the Actor.
        public List<Actor> Actors { get; set; }

        // This prop represent the relation between this table and the Actor table.
        public List<ActorMovie> ActorMovies { get; set; }

    }
}
