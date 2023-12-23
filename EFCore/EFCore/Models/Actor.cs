using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for many-to-many relationship
        // So by adding this Navigation I told the EFC that the Actor has a relation with the Movie model
        //    and this this relation is many from the movie.
        public List<Movie> Movies { get; set; }

        // This prop represent the relation between the Actor and Movie in another Model.
        public List<ActorMovie> ActorMovies { get; set; }


        // This used to refer that the Actors tabel has a relation of one-to-one with the Nationality table.
        public int ActorNationalityId {  get; set; }
        public Nationality Nationality { get; set; }
    }
}
