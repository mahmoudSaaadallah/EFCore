using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Book
    {
        // Here in the book model we don't have any id prop and we want to make the prop bookNumber as
        //   a primary key so we could use Data Annotaion or using Fluent API
        // To use data Annotaion we will write:
        //[Key]
        // If you want to see how to do the same operation using Fluent API back to ApplicationDbContext.OnModelCreating.
        public int bookNumber {  get; set; }
        // I have to know that the primary key now will has the name of PK_Books, but what if i watn to
        //   make it with another name I could do so using Fluent API only not Data Annotaions.
        //   back agin to ApplicationDbContext.OnModleCreating to see it.
        public string title { get; set; }
        public string Author { get; set; }


        // What if I want to make a compsite key to this model I can't do it using Data Annotaions, but I could do it using Fleunt API. 
        // Let's make title and Author to be compisite primary key.
        // back again to ApplicationDbContext.OnModleCreating to see it.




        // Now What if I want to put a default value for a specific column(prop)?
        // I can't do it using Data Annotaions, but I could do it using Fluent API.
        // To See this example back agin to ApplicationDbContext.OnModleCreating to see it.
        public decimal Rating { get; set; }



        // Now what if I want to set a value using a sql funcion to specific prop in database.
        // For example if we have a prop called CreatedOn with datatype dateTime and we want to store on it
        //   the time of creating blog.
        // I could do this operation using Fluent API.not using Data Annotaions.
        // To See this example back agin to ApplicationDbContext.OnModleCreating to see it.
        public DateTime Createdon {  get; set; }

    }
}
