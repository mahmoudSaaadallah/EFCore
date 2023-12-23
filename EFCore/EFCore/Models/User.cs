using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    [Index(nameof(Email))]
    //[Index(nameof(Email), IsUnique = true)]
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // to make a column as an Index then we could use Data Annotaion or Fluent API.
        // To use data Annotaion we could just write [Index(nameof(columnName))] before the class name.
        // Also we could add another attribute like adding IsUnique to make this Index unique
        // We could Also make it by Fluent API go to ApplicationDbContext to see it.
        public string Email { get; set; }
    }
}
