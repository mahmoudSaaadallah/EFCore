using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    internal class ApplicationDbContext : DbContext
    {
        // Our ApplicationDbContext must inherte from DbContext that already built in microsoft.

        // Now I have to override the  OnConfiguring(DbContextOptionsBuilder optionsBuilder) method that 
        //   Accept parameter of type optionsBuilder.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // As we will use sqlserver then I have to make the connection based on the sqlserver.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=EFCore;Integrated Security=True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Fluent API used to make the Url prop in Blog class Required.
            // modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired();


            // There is another way to add new class to database without using DbSet using the following line
            modelBuilder.Entity<AuditEntry>();

            // If I want to make the post class not added to database automaticly because of navegation
            //   then  I could use the  Fluent API like the follwoing:
            //modelBuilder.Ignore<Post>();
            // This line of code will make Post class not automaticly created in database unless you used the DbSet.


            // If I want any table not included in migration mean not to apply changes on this table but
            //   the table will still exsist then I will use the following code.
            // modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());
            // This line of code make the changes to Blogs table not applied in migration, so not applied to database.



            // To change the name of the table inside database we try to use Data Annotaion now let's try
            //    to use the Flunt API
            //modelBuilder.Entity<Post>().ToTable("Posts");
            // This line of code will change the Post table toPosts.
            // Also I could change the name of schema by adding the named parameter schema to the same command
            modelBuilder.Entity<Post>().ToTable("Posts", schema: "Blogging");


            // If I want to change the default schema from dbo to anything else then I will use the next code:
            modelBuilder.HasDefaultSchema("Blogging");
            // This line of code will make the default schema name is Blogging.


            // If I want to map an object as a view like for example if I want to map a view from type
            //    Post which retrun data from database with the same shape of doman modle then
            //    I could use the next line:
            modelBuilder.Entity<Post>().ToView("SelectFromPosts", schema: "Blogging");



            // To make a specific prop not to mapped to database using Fluent API we will use
            modelBuilder.Entity<Blog>().Ignore(b => b.Addedon);
            // This line of code will make the EF ignore the prop Addedon.



            // If you want to add column to database with diffrant name using Fluent API we will use:
            modelBuilder.Entity<Post>().Property(p => p.AddedTime).HasColumnName("PostAddingTime");
            // this line of code will change the name of property Addedon to BlogAddinTime while adding it 
            //    to database.



            // If I want change the datatype of column in data base we could use Fluent API, as we could use Data Annotaions.
            modelBuilder.Entity<Post>().Property(p => p.Rating).HasColumnType("Decimal(5,2)");



            // To use specific length for datatype we could use Fluent API to do it.
            //modelBuilder.Entity<Blog>().Property(b => b.Url).HasMaxLength(200);
            //  this line of code will make the Url prop in blog table has Maximum length of 200 char.



            // To put a comment for specific prop in database using Fluent API
            modelBuilder.Entity<Blog>().Property(b => b.Url).HasComment("This is a comment for Url in data base.");
            // This line of code will make a comment for Url column in database.    




            // In the book model we don't have any id prop and we want to make the prop bookNumber as
            //   a primary key so we could use Data Annotaion or using Fluent API
            // Let's try to make it using Fluent API.
            modelBuilder.Entity<Book>().HasKey(b => b.bookNumber);
            // I have to know that the primary key now will has the name of PK_Books, but what if i watn to
            //   make it with another name I could do so using Fluent API only not Data Annotaions.
            modelBuilder.Entity<Book>().HasKey(b => b.bookNumber).HasName("PK_BookNumber");




            // What if I want to make a compsite key to this model I can't do it using Data Annotaions, but I could do it using Fleunt API. 
            // Let's make title and Author to be compisite primary key.
            //modelBuilder.Entity<Book>().HasKey(b => new { b.title, b.Author });




            // Now What if I want to put a default value for a specific column(prop)?
            // I can't do it using Data Annotaions, but I could do it using Fluent API.
            modelBuilder.Entity<Book>().Property(b => b.Rating).HasDefaultValue(4.0);
            // Now after using this fluent API we could make the default value to the Rating equal to 4.0



            // Now what if I want to set a value using a sql funcion to specific prop in database.
            // For example if we have a prop called CreatedOn with datatype dateTime and we want to store on it
            //   the time of creating blog.
            // I could do this operation using Fluent API.not using Data Annotaions.
            modelBuilder.Entity<Book>().Property(b => b.Createdon).HasDefaultValueSql("GETDATE()");
            // by using the HasDefaultValueSql() and pass the sql function that will retrun the value that 
            //  we need to store in our database then i could use it between double quot






            // Now what if I want to add new column that has data depend on another data in another two
            //   columns Which called computed columns.
            // For example if I want to add a TotalSalary and Taxes in Employees table and want to add new
            //   column called NetSalary which equal to the (TotalSalary - Taxes), We could do this
            //   operation using EFC.
            // We could do it using Fluent API not Data Annetaions.
            // But before we get the NetSalary I have to get first the Taxes from the TotalSalary Column
            // As the taxes is percentage of totalSalary.
            modelBuilder.Entity<Employee>().Property(e => e.Taxes).HasComputedColumnSql("[TotalSalary] * 0.3");
            modelBuilder.Entity<Employee>().Property(e => e.NetSalary)
              .HasComputedColumnSql("[TotalSalary] - (0.3 * [TotalSalary])");






            // If I have a model class called Category This class contain two property Id of type byte
            //   and Name of type string and we want to make it as table in database then the Id prop
            //   Will be primary key for the table of type tinyInt in database, but this id will not
            //   increment automatically So I have to handle this situation using Data Annotaions or using
            //   Fluent API 
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();





            // In Entity Framework Core (EF Core), a one-to-one relationship refers to a situation where
            //   one entity is related to exactly one instance of another entity, and vice versa.
            // This means that each record in the first entity is associated with only one record in the
            //   second entity, and each record in the second entity is associated with only one record in
            //   the first entity.
            // Consider two entities: Person and Address. Each person has exactly one address, and each
            //   address is associated with exactly one person.
            // Let's go to Models folder to create Person model and Address model.
            // We have to know that The Address model here depend on the Person model So The Person model
            //    is the parent and the Adress model is the child.
            // In the context of a one-to-one relationship, the parent entity is often the one that
            //   contains the primary key that is used as a foreign key in the child entity. In this case,
            //   the Person entity has the PersonId property, which is the primary key. The Address entity
            //   has a foreign key property PersonId that references the primary key of the Person entity.
            // The EFC could know which one of the models is parent and which one is the child, but
            //   sometimes it makes a wrong descion, so to handle this situation we could use the Fluent
            //   API to make one of them as a parent and the other as child.
            // Go to ApplicationDbContext.OnModelCreating to see the API.
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Address>(a => a.PersonId);






            //In Entity Framework Core (EF Core), a one-to-many relationship represents a scenario where
            //   one entity is related to multiple instances of another entity.
            // This is a common relationship type in database design.
            // To illustrate a one-to-many relationship, ! Let's consider another example with two
            //   entities: University and Student.
            // In this scenario, each university can have multiple students, creating a one-to-many relationship.
            // Each University can have multiple Students.
            // Each Student belongs to exactly one University.
            // Go to model folder to see both of them
            // The EFC could know which one of the models is parent and which one is the child, but
            //   sometimes it makes a wrong descion, so to handle this situation we could use the Fluent
            //   API to make one of them as a parent and the other as child.
            // Go to ApplicationDbContext.OnModelCreating to see the API.
            modelBuilder.Entity<University>().
                HasMany(u => u.Students)
                .WithOne(s => s.University)
                .HasForeignKey(s => s.UniversityId);

            // I could Write it in another way like I will start first with Student.
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.University)
            //    .WithMany(u => u.Students)
            //    .HasForeignKey(s => s.UniversityId);
            // So of them are correct





            // Now what if I want to make an one-to-many relation, but without using the primary key of
            //  the parent model as a forgine key in the child model, then I have to specifie which column
            //   in parent model will be used as a forginekey in child model using Fluent API.
            // Go to the model folder to see this example with the model of car and RecordOfSale.
            modelBuilder.Entity<Car>()
                .HasMany(c => c.SaleHistory)
                .WithOne(s => s.Car).
                HasForeignKey(s => s.CarLicensePlate)
                .HasPrincipalKey(s => s.LicensePlate);







            // In Entity Framework Core (EF Core), a many-to-many relationship occurs when each entity in
            //   one set can be related to multiple entities in another set, and vice versa.
            // A classic example is the relationship between Actors and Movies: an Actor can act in
            //   multiple Movies, and a movie can have multiple Actors.
            // To represent a many-to-many relationship, you typically introduce a junction (or link) table
            //   that connects the two entities.
            // To see this example go to Models folder to see both of the models.
            // By only use both of the Actor and Movie model with relation of type many to many 
            //    I could make a thrid model that represent the relation between both of the models, by
            //    adding to the third model both of the collection navigation of both of Actor and Movie,
            //    and adding prop that represent the ActorId and another one to represent the MovieId, but
            //    if we didn't make this third model, the EFC will create it automaticall.
            // Also I could figer out this relation to the EFC using FluentApI if something wrong Happen.
            // Go to ApplicationDbContext to see this Fluent API.
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity(x => x.ToTable("ActorMovie"));
            //UsingEntity(x => x.ToTable("ActorMovie")); 
            // I used this line of code to give the new table that will be created to the relation a new
            //   name, so I could call it any name I want.



            // If I already make the third table by myself the I will use the next Fluent API.
            modelBuilder.Entity<Actor>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity<ActorMovie>();






            // If I want to make an Index inside a table then I could use the following Fluent API
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email);
            // Also we could add some feture for this index by using another methods like
            //modelBuilder.Entity<User>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique()
            //    .HasName("Ix_Email");
            // So by writing this API I could make my index unique and I could change its name.



            // Now lets make a composite Index.
            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.FirstName, p.LastName });
            // Now we already make a composite Index in the person table.









            ///Data Seeding
            // Data seeding in Entity Framework Core is the process of populating the database with initial
            //   or default data when the database is created.
            // It's a useful feature for ensuring that your database has some predefined data for testing
            //   or when the application is first deployed.
            // we will try dataSeeding on the Car model to see how to make it.
            modelBuilder.Entity<Car>()
                .HasData(new{ Id = 1, LicensePlate = "307", Model = "BMW" });
            // We have to know something even when the Id is autogenrated we have to add it while we adding
            //   data seeding.
            // Also we could add more that one row at the same time.
            modelBuilder.Entity<Car>()
                .HasData(new { Id = 2, LicensePlate = "703", Model = "Audy" },
                new { Id = 3, LicensePlate = "901", Model = "KIA" });






            modelBuilder.Entity<Actor>()
                .HasOne(a => a.Nationality)
                .WithMany(n =>  n.Actors)
                .HasForeignKey(a => a.ActorNationalityId);

            // This line of code used to make a globel filtering for Employee table.
            modelBuilder.Entity<Employee>().HasQueryFilter(e => e.NetSalary > 0);





            /// Delete Related data:
            // If we have to related tables which they have a relation, so we will find that there is a column that is a
            //   forign key that cames from one of the tables and inside another table.
            // In this situation if we try to delete data from the first table that has primary key as a forgin key in
            //   another table then we have to be aware about the data inside the the other table that has a column as a
            //   forgin key as the data that is releated to the removed data will be deleted also as its refernce deleted.
            // for example we have here table Actor which has a forgin key column comes from Nationality table so If we for 
            //   example delete the nationality Egyption which has a primary key as 1 then all the actors in the table
            //   Actors whoes Nationality is Egyption(has forgin key = 1) will be deleted by default as the database deal
            //   with related data by cascaded which mean by default it delete all data that is related to the deleted data.
            // So If we want to handel this situation to make the related data asigned to Null by default if its related
            //   data deleted then we have to follow the following rule.
            // First We have to make the default action for deleted data to be restriction(not allowing to delete related data)
            // This mean I will make it possible for you to delete a related data before you delete all the child data.
            // So in our example you can't delete the Nationality Egyption until you delete all the Actors that has an
            //   Egyption Nationality.
            modelBuilder.Entity<Nationality>()
                .HasMany(n => n.Actors)
                .WithOne(a => a.Nationality)
                .OnDelete(DeleteBehavior.Restrict);
            // We could handle it with other way by setting null to the related data without deleting it this could happen by
            //   the next line of code.
            modelBuilder.Entity<Nationality>()
                .HasMany(n => n.Actors)
                .WithOne(a => a.Nationality)
                .OnDelete(DeleteBehavior.SetNull);


        }

        // To make any class be a model in database to represent as a table, we have to use the 
        //   generic DbSet of type of the same class name.
        public DbSet<Employee> Employees { get; set; }
        // Now we could add the migration again .

        public DbSet<Blog> Blogs { get; set; }

        // The following function used to test the  Fluent API to make a specific property requeried 
        // We have to know that using  Fluent API is better than using  Data Annotaions.
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired();
        //}


        // I don't have to use the following line of code as the Post class already used as A navegation
        //   inside Blog class so adding Blog to data base mean adding any class that used as Navegation
        //   inside blog
        //public DbSet<Post> Posts { get; set; }

        // There is another way to add class to database without using DbSet back to OnModelCreating method. 

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RecordOfSale> RecordOfSales { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}

