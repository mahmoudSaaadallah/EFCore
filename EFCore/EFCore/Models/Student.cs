using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        // Foreign key property for one-to-many relationship
        // This mean the UniversityId prop will be the foreign key from the Uniersity Model, The EFC will 
        //    know that as there is a collection Navigation on the Uniersity model that say that the
        //    University model contain a list of Student model.
        // And also this model contain the navigation from the University that says there is a relation
        //    between this model and the University model, and also allow to move from this modle to the
        //    other one.
        public int UniversityId { get; set; }

        // Navigation property for one-to-many relationship
        public University University { get; set; }
    }
}
