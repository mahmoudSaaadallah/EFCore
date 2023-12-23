using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    [Index(nameof(FirstName), nameof(LastName))]
    internal class Person
    {
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property for one-to-one relationship.
        // This following line called a Navigatgtion which handle the one to one relationship, I have to
        //   know that this prop will not apeare in table inside database, It just used to tell the EFC
        //   that there is a relation between this model(Table) and adress model(Table).
        public Address Address { get; set; }


        // Let's say I want to make a composite index consist of two columns for example consist of
        //    FirstName and LastName.
        // We will use the following DataAnnotaion before the class name.
        //   [Index(nameof(FirstName), nameof(LastName))]
        // Or we could use Fluent API back again to ApplicaionDbContext to see it.

    }
}
