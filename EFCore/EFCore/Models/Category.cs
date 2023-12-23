using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Category
    {
        // I have a model class called Category This class contain two property Id of type byte
        //   and Name of type string and we want to make it as table in database then the Id prop
        //   Will be primary key for the table of type tinyInt in database, but this id will not
        //   increment automatically So I have to handle this situation using Data Annotaions or using
        //   Fluent API.
        // First using DataAnnotaions:
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        // This DataAnnotaion will make the Id as Identity So It will be auto Increment.
        // To see the Fluent API that handle this problem go to ApplicationDbContext.OnModelCreating



        [Required, MaxLength(100)]   
        public string Name { get; set; }
    }
}
