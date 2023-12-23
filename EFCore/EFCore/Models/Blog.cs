using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Blog
    {
        public int Id { get; set; }

        // If I want to make the Name prop required I could use wthe  Data Annotaions like this:
        //[Required]
        public string Url { get; set; }
        // Or We could use  Fluent API inside ApplicationDbContext, or inside other class that contain all 
        //    the Fluent API code to be better and use a refernce of this class in ApplicationDbContext.
        // Go to ApplicationDbContext to see how to make Fluent API

        // There is another way by writing requier in the implemention of prop.
        //public required string Url { get; set; }

        // We have to know that in c# 12 the string type is required by default.

        // As we said before the string in c#12 is required then if I want to make any prop not required then I have to write the data type followed by nullable sign like(string?, int?, float?).
        //public string? Url { get; set; } this will allow null.





        /*
           
            2- Collection Navigation Property:

            Represents a collection of related entities.
            Used in one-to-many or many-to-many relationships.
            Example:
            public class Course
            {
                public int CourseId { get; set; }
                public ICollection<Student> Students { get; set; } // Collection navigation property
            }

         */
        public List<Post> Posts { get; set; }
        // As I added here a navagation prop from another class then I don't have to add the Post class
        //   to ApplicationDbContext to create a new table with the name of Post, becaues the EF will
        //   automaticly set the Post class to be a model and create it in database.

        // If I want to make the post class not added to database automaticly because of navegation then 
        //   I could use the Data Annotaions like the follwoing:

        //[NotMapped]
        //public List<Post> Posts { get; set; }

        // by using this Data Annotaions I will make the Post class not mapped which mean not automatily created without add it to ApplicationDbContext.
        // There is another way to do the same thing using  Fluent API back to ApplicationDbContext.




        // Now What if I want to add a property in class and not need to map this prop in database 
        // We will use of of Data Annotaions or Fluent API like what we did with table it self
        //[NotMapped]
        public DateTime Addedon {  get; set; }
        // Now If try to add new migration to database then this prop will not add as we use the Data
        //   Annotaions to make it not Mapped.
        // Also we could do it with Fluent API. back to ApplicationDbContext.OnModleCreating.





        // If I want to add a comment for column in database we could use Data Annotaions or using Fluent API
        // [Comment("This is a comment for column in database")]
        // If we used this data Annotaion before any prop this comment will apear in database.
        // Also we could do it using Fluent API.Back to ApplicationDbContext.OnModelCreating.


    }
}
