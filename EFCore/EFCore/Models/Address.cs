using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Address
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        // Foreign key property for one-to-one relationship
        // The PersonId will be the foreign key for from the Person table as the name of of this perop is 
        //   PersonId, and the Address modle contain prop Person of type Person, this mean the Address
        //   tabel has a relationship between the Person table of type one-to-one.
        public int PersonId { get; set; }

        // Navigation property for one-to-one relationship.
        // This property will not appeare in table inside database it just used to make it clear to EFC
        //   that, the Address table has a relation with the Person table.
        // Because of this prop exist the EFC will know that The PersonId is a foreign key. 
        public Person Person { get; set; }
    }
}
