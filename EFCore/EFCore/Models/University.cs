using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class University
    {
        public int Id { get; set; }

        [Required]
        public string UniversityName { get; set; }

        // Navigation property for one-to-many relationship
        // The following Collection show that the relation between thsi model and the student model which
        //   mean this model has a relation of One-to-Many.
        // This model is the parent model and the other one is the child model.
        public List<Student> Students { get; set; }
    }
}
