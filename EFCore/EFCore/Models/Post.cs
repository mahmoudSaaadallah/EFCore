using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EFCore.Models
{
    //[Table("Posts", Schema = "blogging")]
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // This mean the content prop is nullable which allow null.
        public string? Content {  get; set; }


        // The following prop is type of Blog Class model this called a navigation property.
        // A navigation property is a property on an entity class that represents a relationship between
        //   that entity and another entity.
        // Navigation properties are used to navigate from one entity to another in the object-oriented
        //   domain model, mirroring the relationships defined in the database schema.
        public Blog Blog { get; set; }
        /*
          There are two types of navigation properties:

            1- Reference Navigation Property:

            Represents a single related entity.
            Often used to represent foreign key relationships in the database.
            
            public class Order
            {
                public int OrderId { get; set; }
                public Customer Customer { get; set; } // Reference navigation property
            }


            2- Collection Navigation Property:

            Represents a collection of related entities.
            Used in one-to-many or many-to-many relationships.
            Example:
            public class Course
            {
                public int CourseId { get; set; }
                public ICollection<Student> Students { get; set; } // Collection navigation property
            }

        Navigation properties are crucial for defining and working with relationships between entities. 
        They simplify the navigation between related entities in your application and allow you to express
        relationships in a more natural, object-oriented way.
         */




        // Now what if I want to chage the name of tabel inside database?
        // As I already added this table in database with the name of Post and if I want to change the name
        //   to Posts then I could use Data Annotaions to change the name of it.
        // back again to the line before the class name to see the Data Annotaions.
        // Also by the same way I could change the schema name which is by default dbo, I could change it
        //   using Data Annotaions and this step is optional not mendatory.
        // So If I used [Table("Posts", Schema = "blogging")] before the class name Then this class will be
        //   created in database with the name of Posts into the SchemaName Blogging.

        // This was the first way to change the name of the table in database.
        // There is anothere way to changer the table name in database usig Flunt API, back to 
        //   ApplicationDbContext to see this API in OnModelCreating method.
        // Alos We could change the name of Schema using Flunt API.



        // Now What if I want to change the name of prop(column) while adding it to database, and use
        //   another name in the class here.
        // let's try to add new prop with specific name here in class and add it to database with another class
        // we could use one Data Annotaions or Fluent API like what we did with table name.
        //[Column("PostAddingTime")]
        public DateTime AddedTime { get; set; }
        // Now after useing dataAnnotaions then the AddedTime prop will be added to database with name
        //   BlogAddingTime
        // Also we could use Fluent API to do the same thing, so back again to AppicationDbContext.OnModelCreating.



        // Also I could change the data type of column in database using Data Annotaions to change the type
        //   of column in database like:
        // [Column(TypeName = "varchar(200)")]
        // The previous data Annotaions will change the type of column to varchar of length 200 if it used 
        //   with prop.
        // let's try an example.
        //[Column(TypeName = "Decimal(5,2)")]
        public decimal Rating {  get; set; }
        // I could do the same operation using Fluent API. back to ApplicationDbContext.OnModelCreating.




        // I could also change the length of datatype without changing the datatype of column using 
        //   Data Annotaions like the following:
        //[MaxLength(100)]
        // This mean the maximum length is 100.
        // Also we could do the same using Fluent API.

    }
}
