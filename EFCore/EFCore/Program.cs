using EFCore.Migrations;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace EFCore
{
    public class Programe
    {
        public static void Main(String[] args)
        {
            // This project we will learn how to use the entity frame work.
            // At first we have to install EntityFrameworkcore package 
            // 2- we have to install Microsoft.EntityFrameworkCore.SqlServer
            // 3- we have to install Microsoft.EntityFrameworkCore.Tools

            // Then we have to make a new class which is ApplicationDbContext to contain all the entitys or
            //  the the tables in database.

            // Now after creating the ApplicationDbcontext and create connection with sqlserver database
            // let's start creating the first class which will represent a table in database.

            // The first tabel in database will be employee so we will make the class Employee that
            //    represent the first table in database.
            // We have to be aware about the naming as we will name the class Employee not Employees as
            //    the entity frame work automaticly will add the letter 's' at the end of class name
            //    while it sending it to database.

            // Until now there is no data base called EFCore in sqlServer, so the entity framework
            //   resposable for checking if there is a data base with this name or not and to add
            //   modification or create the database if the database don't exsist.

            // To make the entity frame work do its job then we have to go to Package Manager Console the
            //   use the next command line to do it.
            // add-migration anyName : this line of command will creat new migration with the anyName that
            //   you will use.
            // After we Add the first migration you will find the a new folder created in the project with
            //   name Migrations which save all the history of migrations.
            // Now if we look at the migration that created you will find it empty.
            // Inside the migration you will find two important functions one of them is up and the other is down.
            // The up function contains the updates that will be added to database after you change in your class.
            // It contains the code that creates or modifies database objects, such as tables, columns, indexes, etc.
            // When you run the migration using the "dotnet ef database update" command, the Up function
            //   is executed to apply the changes to the database.

            // The down function contains the previse changes of data.
            // The Down function is the reverse of the Up function. It contains the code to undo the
            //   changes made by the Up function.
            // If you need to roll back a migration (i.a., undo the changes introduced by a specific
            //   migration), the Down function is executed.
            // It is essential for database migrations to be reversible, and the Down function ensures
            //   that you can revert to the previous state of the database.

            // As the migration was empty because we didn't make the ApplicationDbContext make the
            //   Employee class as doman model which mean it will convert to a table in database.
            // So we will remove this migration using the Remove-Migration and add it again
            //   after make the Employee calss as a doman model.

            // Now after deleting the migration we have to go to the ApplicationDbContext and make Employee model.

            // Now after adding the Dbset of Employee in ApplicationDbContext, Let's try to add the
            //   migration again.

            // Now after adding the migration again we will find that the up funciton in the migration 
            //   contain the updated data that will be added to database like creating table with name
            //   Employee and automaticly make the id as a primary key.
            // Also the down funciton will contain the undo which contain drop table Employee.
            // You have to read the migration file befor update it to make sour that the changes that you
            //   want will be added.

            // Now to submit what we did in Migration we will use the update-database command, which will
            //  convert migration to database to create tables.

            // Now after using the update-database command we will find that the new database will be
            // created in sqlserver with the same name that we used in connection of ApplicationDbContext.
            // optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=EFCore;Integrated Security=True");
            // Here Initial Catalog is the name of database.


            // now let's learn how to insert data in tables in database.
            // First we have to make an object of ApplicationDbContext.
            var _context = new ApplicationDbContext();

            // then let's make a new object of Employee that will contain data that will be added to database.
            // I will creat object and initalize it directly, but we have to know that we can't give Id in
            //   employee object value as it's auto genrate by database and it's a primary key.
            //var employee = new Employee {Name = "Mahmoud"};
            // If i tried to enter value to id in employee object it will case an error while i insert it
            //   into database.

            // now I have to use the object of ApplicationDbContext to insert the data of object employee
            //   into database.
            // We have to know that dealing with _context to add new data is like dealing with lists.
            //_context.Employees.Add(employee);
            // Until now nothing added to database as I didn't save the changes all what I did will stay
            //   in memory(RAM) until I save changes.
            // So I could add more than one employee to the table or add another data to another table if
            //   it is exisit, then we could save the changes at the end.

            // To save the changes we will use method SaveChanges() in DbContext.
            //_context.SaveChanges();
            // Now let's try to run the programe and see changes.
            // After running the programe and see what changed in table employee we will find that the
            //   employee object alread added to database.


            // Now if look at the table inside database we will find that there is a new table already
            //   created while creating database called __EFMigrationsHistory
            // This table save the history of migrations.
            // As we make only one migration so there will be one record at table of __EFMigrationsHistory
            // But what if i want to delete this migration? 
            // In this case I can't run remove the migration using remove-migration command as the
            //   migration already added to database so if I want to remove a migration i have to update
            //   an old migration.
            // like if I have 10 migration, and I want to back to migration nubmer 6 which mean I want to
            //   delete the migration number 10, 9, 8, and 7, so I will used update-database followed by
            //   the name of migration that you need to back to, So  here I will updata migration number 6
            // So if used update-database migration6 then the entity framework will run the down function
            //   in migration 10, and 9 and 8 and 7.

            // But here in our example I can't update the last migration as there is just one
            //    migration so if I want to delete this migration I have to back to migrtaion 0
            // To do so I will use (update-migration -migration:0) 
            // This command will back to the state before any migration which mean It will rum the down 
            //    function in the first migration.


            // Now after running the previous command I will find that the migration file in the project 
            //   not removed, but the recored of the first migration in migration table. 
            // To delete the migration file I have now to use remove-migration command to delete this file



            // Now if want to add data to table while the creation of this table(predefine data) for
            //   example if I have a table called department and this table contain some recoreds like
            //   hr and pr then while I create this table when the migration class created after using 
            //   the (add-migration name) command I could add some sql commands tha will insert records
            //   into table automaticlly it be created.
            // I have to go the migration file and writ inside the up function the next line of code:
            // migrationBuilder.Sql("");  then between double quote i could write any sql command which
            //   will be run while update migration.

            // go to file 20231211223513_migration2 inside Migrations file to see this example.
            // for example I will try these steps to employee table and use this command
            // migrationBuilder.Sql("INSERT INTO Employees (Name) VALUES ('Ahmed')");
            // Here I put a sql command between double quote inside sql. This line of code will be run
            //  while you update migration.

            // Also we have to put another line of code that undo this command in down function.
            // So inside down function I will use the next code.
            // migrationBuilder.Sql("DELETE FROM Employees WHERE Name = 'Ahmed'");
            // This line of code will cancle what happen in up function.


            // Now I have two migrations initalCreate(The first one) migration2(The second one)
            // if I want to back to the first migration I will use the next command:
            // update-database 20231211194908_initalCreate 
            // or using update-datebase itialCreate
            // both of them will retrun to the first migration.
            // I have to know something when I updated previous migration this not mean the migration2
            //   file will be deleted as this file will still exsist until you remove it by write the 
            //   remove-migration which will remove the last migration.
            // The resone of not deleteing the file of migration2 is the EFC consider that you may need to
            //    use this migration again by updata-database command followed by the name of migration.


            // Now let's try to see if I have a property that I want it be required then I have several ways
            // One of them is using Data Annotaions in model class.
            // The second way is using Fluent API in ApplicationDbContext class.
            // let's try to make a new model to test both of these ways.
            // Go to Blog model to see the both two ways.
            // As I have now more than model then I will make a new folder with name Models to contain models.


            // After adding the post table to database if we look at the adding_Post migration we will
            //   find that in line 31 there is code say: onDelete: ReferentialAction.Cascade);
            // this line of code happen as I have a relation between blog and post modle so this line mean
            //   if you delete a recored form blog this will case delete any recored that contain the same
            //   value of this blogid because of relation between tables.
            // We could change this Action like making it Restrict:  onDelete: ReferentialAction.Restrict
            //   this line will make the deletion of record from blog table not allable if this record
            //   reflect to post table.





            // We know that when i add a new model to database if this model contain prop with name id, or
            //    class name followed by id, then the EF will automaticly make this prop as a primarykey
            // But what if didn't use prop with id name, or I want to make the id by my self then I have
            //    to data Annotaions or using Fluent API to do it. go to Book Model to see.




            // After Adding the Rating prop to Bools Class, and making the intial value for this column = 4.0
            // Now let's try to add new record to this table.
            //var book1 = new Book { Author = "Mahmoud", title = "EFC" };
            //_context.Books.Add(book1);
            //_context.SaveChanges();


            // Now what if I want to add new column that has data depend on another data in another two
            //   columns Which called computed columns.
            // For example if I want to add a TotalSalary and Taxes in Employees table and want to add new
            //   column called NetSalary which equal to the (TotalSalary - Taxes), We could do this
            //   operation using EFC.
            // We could do it just using Fluent API not Data Annotaion.




            // If I have a model class called Category This class contain two property Id of type byte
            //   and Name of type string and we want to make it as table in database then the Id prop
            //   Will be primary key for the table of type tinyInt in database, but this id will not
            //   increment automatically So I have to handle this situation using Data Annotaions or using
            //   Fluent API 
            // Go To Category Model to see the changes






            //------------------------------------------------------------------------------------------//
            ///<Relations></Relations>
            ///

            ///one-to-one
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




            ///One-to-Many
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


            // Now what if I want to make an one-to-many relation, but without using the primary key of the
            //   parent model as a forgine key in the child model, then I have to specifie which column
            //   in parent model will be used as a forginekey in child model using Fluent API.
            // Go to the model folder to see this example with the model of car and RecordOfSale.




            /// Many-to-Many
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

            // It will be better if you make the third model that represent the relation by yourself not 
            //    to depend on the EFC to make it.









            // Indexes in a database model are used to enhance the performance of queries by providing a
            //   quick lookup mechanism for specific columns.
            // In Entity Framework Core (EF Core), you can use data annotations or Fluent API to define
            //   indexes on your model.
            // Let's look at an example using data annotations for an index on the Email property of a User
            //   model 


            // Also I could make a composite index by using mulit column to apply this to it.
            //  Let's go to the user person model to see it.







            ///Data Seeding
            // Data seeding in Entity Framework Core is the process of populating the database with initial
            //   or default data when the database is created.
            // It's a useful feature for ensuring that your database has some predefined data for testing
            //   or when the application is first deployed.
            // Lets go to ApplicationDbContext to see The Fluent API that make this data seeding

            // Also we could make data seeding in a seprated function and call this function inside main 
            //   Which will be occered when the programe run.










            /// Dealing with Migration\
            // When we dealing with migration we have different command to handle migration, but the
            //   following command used only with visual studio.
            // Add New Migration Add-Migration NameOfMigraion.

            // Updates your database to the latest migration ==> Update-Database

            // Updates your database to a given migration ==> Update-Database TheNameOfSpacificMigration

            // Remove Last Migration ==>  Remove-Migration

            // Generates a SQL script from a blank database to the latest migration AddNewTables ==>
            //     Script-Migration
            // The Script-migration used to get the sql script that will applied to database from the first
            //   migration to the last one.

            // Generates a SQL script from the given migration to the latest migration
            //   ==> Script-Migration TheNameOfMigration
            // we adding the name of Migration that we want the script to applied after it.

            // Generates a SQL script from the specified from migration to the specified to migration ==>
            //    ==> Script-Migration FirstMigration SecondMigration.

            // List existing Migration ==>  Get-Migration







            /// Working with exsisting database.
            // If you are working with exisiting data base, and you want to add this database to your
            //   project by creating models from that database and also make FluentAPI and DBContext
            //   automatically from data base we could use the following command:
            // scaffold-dbContext 'Data Source=connectionOfyourDataBase;Initial Catalog=NameOfDatabase' Microsoft.EntityFrameworkcore.sqlserver
            // To more details:   https://www.youtube.com/watch?v=HZe9hGLTQ_g&list=PL62tSREI9C-cHV28v-EqWinveTTAos8Pp&index=37&pp=iAQB
            //










            // Now list start selecting data from database.
            // To select all data from spacific table we have to use an instance of ApplicaionDbContext.
            var result1 = _context.Employees.ToList();
            foreach (var employee in result1)
                Console.WriteLine(employee.Name + "\t\t : \t\t" + employee.NetSalary);
            // We have to know that here result1 select all the recoreds from the table Employees which will
            //   effect the preformance as we don't need to select all the columns in this table we just
            //   need to get the name and the netSalary columns so It's better to specify which data you
            //   need from database.


            // If I want to select specific item from database We could use one of the filter ways like
            //    using Find method.
            // We have to know that Find method accept the primary key of the record that we look for.
            var result2 = _context.Employees.Find(15);
            Console.WriteLine($"Id:{result2.Id}  Name: {result2.Name}"); // Id:15  Name: khder



            // The second way to select specific item is by using single:
            // We could use single without any criteria which will return the record if there is no other
            //   records in the table execpt this one, and will return error if there is more than one
            //   record in the table or if there is no records in the table.
            // Or we could use single with specific criteria to select a specific row depend on this criteria 
            var result3 = _context.Employees.Single(e => e.Id == 15);
            Console.WriteLine($"Id:{result3.Id}  Name: {result3.Name}");// Id:15  Name: khder
            // We could use singleOrDefault to avoid exceptions.
            // As we used singleOrDefault with criteria and it found no rows that satisfay this criteria
            //   then it will return default value bur if it found more than one row it will return an exception.
            result3 = _context.Employees.SingleOrDefault(e => e.Id == 6545);
            Console.WriteLine(result3 == null ? "No items founded" : $"Id:{result3.Id}  Name: {result3.Name}");// No items founded.
            // we could use more than one criteria with single.
            result3 = _context.Employees.Single(e => e.Id == 15 && e.Name == "khder");
            Console.WriteLine($"Id:{result3.Id}  Name: {result3.Name}"); // Id:15  Name: khder
            result3 = _context.Employees.Single(e => e.Name.StartsWith("j"));
            Console.WriteLine($"Id:{result3.Id}  Name: {result3.Name}"); // Id:22  Name: Joudy



            // The Third way to select specific item is by using First:
            var result4 = _context.Employees.First(); // return the first row in table.
            Console.WriteLine ($"Id:{result4.Id}  Name: {result4.Name}"); // Id:10  Name: Mahmoud
            // Also we could add a specific criteria to first.
            result4 = _context.Employees.First(e => e.Name.StartsWith("o"));
            Console.WriteLine($"Id:{result4.Id}  Name: {result4.Name}"); // Id:14  Name: Omar

            // We have to know that if the first doesn't found any row that satisfay this criteria then it will return an exception.
            // To avoid the Exception we could use FirsOrDefault.
            result4 = _context.Employees.FirstOrDefault(e => e.Name.StartsWith("z"));
            Console.WriteLine(result4 == null ? "There is no item." : $"Id:{result4.Id}  Name: {result4.Name}"); // There is no item.




            // The fourth way to select one record is by using last:
            // We have to know that last must be used with orderby, or it will return an exception.
            var result5 = _context.Employees.OrderBy(e => e.Id).Last();
            Console.WriteLine($"Id:{result5.Id}  Name: {result5.Name}"); // Id:24  Name: Azza

            // Also we could use it with specific criteria:
            result5 = _context.Employees.OrderBy(e => e.Id).Last(e => e.Name.StartsWith("o"));
            Console.WriteLine($"Id:{result5.Id}  Name: {result5.Name}"); // Id: 21  Name: Osman

            // We could use LastOrDefault to avoid exceptions.
            result5 = _context.Employees.OrderBy(e => e.Id).LastOrDefault(e => e.Name.StartsWith("z"));
            Console.WriteLine(result5 == null ? "There is no item." : $"Id:{result5.Id}  Name: {result5.Name}"); //There is no item.


            // We said before if i want to to select all the data from table then we have to use ToList()
            result1 = _context.Employees.ToList();
            // But sometimes we don't have to select all this data, as if I have lot of data then it will
            //   take lot of time to select all of them each time I want data, so we learned how to select
            //   a specific data to avoid selecting extra data but using different ways like selecting
            //   using Find, Last, First, or single which used to select all a specfic record from database.
            // Now What if I want to select more than one record but not all the record, like makeing
            //    filtering for data that I will select from tabel. I could do so using Where which used to
            //    filter data that it will be selected.
            Console.WriteLine("----------------------------------------");
            var result6 = _context.Employees.Where(e => e.Id > 10);
            foreach ( var e in result6)
                Console.WriteLine($"Id:{e.Id}  Name: {e.Name}");
            // We have to know that all that data inside the table doesn't send to the enduser then filter
            //    it filtered first then the result of filteration send to the end user as a list.
            // So all the filtereatio that happen at the server side will increase the preformance as when
            //   the filter happen inside database server it will take less time than when it happen in the
            //   user side.
            // I could Also use more than one criteria with where to filter with more layer of filteration.
            Console.WriteLine("--------------------------------------------");
            var result7 = _context.Employees.Where(e=> e.Id > 10 && e.Name.StartsWith("o"));
            foreach(var e in result7)
                Console.WriteLine($"Id:{e.Id}  Name: {e.Name}"); // Id:13  Name: Omran
                                                                 // Id: 14  Name: Omar

            // If we want to use criteria of type bool we don't have to use == Ture or == False to check if 
            //   The variable is true or false, If I check the var is true the I just write the name of the
            //   variable without any other thing, but if I want to check if the variable is flase then I
            //   have to use ! with the variable name.



            // ANY   &&   ALL
            // Now when I want to check if the table contain at least one record then we could use any()
            var result8 = _context.Employees.Any();
            Console.WriteLine(result8); // True
            // So any reutrn True if the table contain at least one record or false if the table is empty.
            // we could use a specific critira with any to check if the table has at least one record that 
            //    satisfy this critira.
            result8 = _context.Employees.Any(e => e.Name.StartsWith("z"));
            Console.WriteLine(result8); // False
            // Now it will return false as there is no record has a Name start with Z letter.

            // All used to check that if all records in the table staisfy a specific critira.
            result8 = _context.Employees.All(e => e.Name.Length > 3);
            Console.WriteLine(result8); // True
                                        // It will return True as all the names length in the Employee table are greater than 3

            result8 = _context.Employees.All(e => e.TotalSalary >= 1000 && e.Taxes >= 300);
            Console.WriteLine(result8); // False
            // AS not all the employees have salary greater than 1000 and Their taxes not greater than 300.

            
            // We have two methods that used to add new record at the end of list or at the beging of the
            //   list  Append   &&  prepend
            // We could use both of them if I select data from database and transfar it to list then we
            //   could use both of them with list.
            var result9 = _context.Employees.Where(e => e.Id > 10).ToList().Append(new Employee { Id = 7, Name = "Mahmoud", TotalSalary = 70987});
            foreach ( var e in result9) 
                Console.WriteLine($"Id:{e.Id}  Name: {e.Name}");
            // We have to know that the append and prepend doesn't add a new record to database it just add
            //   record at user side not at server side so when we back again to database the record that
            //   added using append will not exsist.
            // So we use both of them at runtime to add extra infomation to user.




            /// Aggrgate Function  or  Extenstion Methods.
            // Average().
            // The Average function used to get the avarage for specific column if this column contain
            //    numeric data.
            // Like if I want ot get the average salary for all employees I will add all the employees
            //   salary then divied the result into the number of employees. This what the Average function do.
            var result10 = _context.Employees.Average(e => e.TotalSalary);
            Console.WriteLine(result10); // 29295.818181
            // Also I could use avarage function with where to get the avarage value for specific number of
            //   rows not all the rows inside the column.
            result10 = _context.Employees.Where(e => e.TotalSalary >= 20000).Average(e => e.TotalSalary);
            Console.WriteLine(result10); // 61622.222222
            // Now I get the average salary for employees that have totalSalary greater than 20000.

            // Count()
            // used to count number of rows in table.
            result10 = _context.Employees.Count();
            Console.WriteLine(result10); // 22
            // If I want to count number of rows that satisfiy specific critira then I could use this
            //   critira inside count directly without using where before it.
            result10 = _context.Employees.Count(e => e.TotalSalary > 50000);
            Console.WriteLine(result10);// 5

            // We have to know that count return data of type int32, so if I have a big number bigger than
            //   int then we have to use longCont instead of count.


            // Sum()
            // used to get the sum of records in specific coulumn. 
            // It has the same rules that the Average has.
            var result11 = _context.Employees.Sum(e => e.TotalSalary);
            Console.WriteLine(result11);// 644508.00
            // Alo I could use where before the sum to sum specific caritiria.
            result11 = _context.Employees.Where(e => e.Id > 16).Sum(e => e.TotalSalary);
            Console.WriteLine(result11);// 251272.00


            // Min()
            // Used to select the minimum value in specific column.
            // It could be used with filtering using where or not.
            result11 = _context.Employees.Min(e => e.TotalSalary);
            Console.WriteLine(result11); // 0.00
            // We use where with it to applay specific critiria.
            result11 = _context.Employees.Where(e => e.Id > 15).Min(e => e.TotalSalary);
            Console.WriteLine(result11); // 6473.00


            // Max()
            // used to select the maximum value in specific column.
            // It could be used with filtering using where or not.
            result11 = _context.Employees.Max( e=> e.TotalSalary);
            Console.WriteLine(result11); // 98423.00

            result11 = _context.Employees.Where(e => e.Name.StartsWith("o")).Max(e => e.TotalSalary);
            Console.WriteLine(result11); // 7712.00





            /// Sorting:
            // Orderby().
            // The orderby method used to order data that selected from table by specific column
            var result12 = _context.Employees.OrderBy(e => e.TotalSalary);
            foreach(var e in result12)
                Console.WriteLine($"Name: \t {e.Name}  |   NetSalary: \t {e.NetSalary}");
            // The default ordering here is in Asscending way from smaller to greater. 
            // We could use orderby with column that contain string not only numbers.
            result12 = _context.Employees.OrderBy(e => e.Name);
            foreach (var e in result12)
                Console.WriteLine($"Name: \t {e.Name}");
            // Now we have to know that when we order string it ordering by the order of letters start with A go to Z.

            // As we said the orderby start ordering in Assending way by default, but if I want to order in Descending //
            //   way we could use OrderbyDescending.
            result12 = _context.Employees.OrderByDescending(e => e.TotalSalary);
            foreach (var e in result12)
                Console.WriteLine($"Name: \t {e.Name}  |   NetSalary: \t {e.NetSalary}");
            // If I have column that contain a repeating data and we want to order it in a specific way, and we also want
            //   to order another column depend on the ordering that happen in the first order, so we could use Then by.
            Console.WriteLine("-------------------------------------------");
            result12 = _context.Employees.OrderBy(e => e.Name).ThenByDescending(e => e.TotalSalary);
            foreach (var e in result12)
                Console.WriteLine($"Name: \t {e.Name}  |   NetSalary: \t {e.NetSalary}");





            /// Selec()
            // We could use select function to select specific coulumn not selecting all the columns inside database.
            Console.WriteLine("-------------------------------------------");
            var result13 = _context.Employees.Select(e => new { e.Name, e.Taxes } ).ToList();
            foreach(var e in result13)
                Console.WriteLine($" Name: \t {e.Name}   Taxes: \t {e.Taxes}");
            // Also I could change the name of column that returns from database.
            Console.WriteLine("-------------------------------------------");
            var result14 = _context.Employees.Select(e => new { Employee = e.Name, Salary = e.NetSalary}).ToList();
            foreach (var e in result14)
                Console.WriteLine($" Name: \t {e.Employee}   Taxes: \t {e.Salary}");




            /// Distinct()
            // We use Distinct method to select a unique values from column as it just get one value of the Duplicate
            //   values. 
            // We have to know that the Distinct method doesn't accept any data or expressions, so if I want to apply the
            //   Distinct to specific column, then I have to use Select before it.
            Console.WriteLine("-------------------------------------------");
            var result15 = _context.Employees.Select(e => e.Name).Distinct();
            foreach (var e in result15)
                Console.WriteLine($" Name: \t {e}");
            // Now it will return all tha names without any repeating as it delete the duplicate value.



            /// Skip()  && Take()
            // We use Skip and Take methods to skip specific data from table and take specific data.
            // The Skip and Take methods accept numbere which mean If I use Skip(10) then It's mean skip the first 10
            //   rows, then after it if I use Take(5) this mean select form 11 to 15.
            var result16 = _context.Employees.Skip(10).Take(7).ToList();
            foreach(var e in result16)
                Console.WriteLine($"Id: \t {e.Id} \t Name: \t {e.Name}");
            // This will start selecting rows from 11 to 17.
            // The best example for using skip and take is when we want to display data in a page and we have data bigger
            //   than the page size then we have to select number of rows that will be able to appear in this size then
            //   when we go to the page2 we will skip the data that we already selected in the first page then we take
            //   the data after it, and so on.




            /// GroupBy()
            // We could use GroupBy to get data from table depend on a specifc group like if I want to get names of
            //   employees and how many times does specific name repeated we could use group by .
            var result17 = _context.Employees.
                GroupBy(e => e.Name)
                .Select(e=> new {Name = e.Key, count = e.Count()})
                .ToList();
            foreach (var e in result17)
                Console.WriteLine( $"Name {e.Name}  count {e.count}");
            // So At the first it group all the same name as a group then it select a.key as Name which mean key here is
            //   the same as the grouping element(Name), then we select count for each group.




            /// Join()
            // Now let's learn how to join mulit table with each other to get data from all of them at the same time
            //   depend on a common column between them 
            // As we have an Actor table and a Nationalty table, and they have a relation of one to many so we could
            //   get the Actor name and his Nationality from different tables.
            var result18 = _context.Actors
                .Join( _context.Nationalities,
                       Actor => Actor.ActorNationalityId,
                       Nationality => Nationality.Id, 
                       (a, n) => new
                       {
                           Name = a.Name,
                           Nationality = n.Name
                       });
            foreach(var a in result18)
                Console.WriteLine($"Name: \t {a.Name}\t Nationality: \t{a.Nationality}" );
            // So We have to know what we have to write inside Join method:
            // First we have to write using context the name of table that will be joined with our table like in this
            //   example we wrote the Nationalities as the joined table with Actors.
            // Second we have to write the column that is common between both of these tables using the exction from each table.
            // then we have to write the exction as a new object that contion the coulumn that You want to select from of
            //   the joined tables.


            // Also we could join tree tables at the same time, by joining the result of the first join with another table.
           var result19 = _context.Actors
                .Join(
                        _context.Nationalities, 
                        Actor => Actor.ActorNationalityId, 
                        Nationality => Nationality.Id,
                        (a, n) => new
                        {
                            ActorId = a.Id,
                            ActorName = a.Name,
                            Nationality = n.Name
                        })
                .Join( _context.Movies,
                       Actor => Actor.ActorId, 
                       Movie => Movie.Id,
                       (a, m) => new
                       {
                           ActorId = a.ActorId,
                           a.ActorName,
                           a.Nationality, 
                           MovieName = m.MovieTitle
                       }
                      );
            foreach (var a in result19)
                Console.WriteLine($"ActorId: \t {a.ActorId} \t Name: \t {a.ActorName} \t Nationality: \t {a.Nationality} \t Movie: \t {a.MovieName}");





            /// Tracking and NoTracking:
            // We have to know that EFC by default apply tracking to track the changes that happen to database, so If you
            //   select data from database and this data changed at the same code of selecting this will make the result
            //   change as the data changed.
            // So If I want to make the EFC or The LINQ not appling tacking each time you select data then we could use
            //   AsNoTracking() method with LINQ expression.
            Console.WriteLine("----------------------------------------------------");
            var result21 = _context.Employees.AsNoTracking().ToList();
            foreach(var a in result21)
                Console.WriteLine($"Id:  {a.Id} \t Salary: \t {a.NetSalary}");
            // We have to know that the tracking make the preformance of the programe more slower, so we could make it more fater by stop tarcking.

            // We could also change the default tacking behavior to make it noTracking by default using the next line
           // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;




            /// Eager loading
            // If I want to select data form table and get a related data from another table at the same query like join
            //    for example If I want to get the name of the Acotrs from Actors table, and the Nationality 
            //    from the Nationalities table then we could use the EagerLoading using Include method.
            var result22 = _context.Actors.Include(a => a.Nationality).ToList();
            foreach(var a in result22)
                Console.WriteLine($"Name: \t {a.Name}\t  Nationality: \t {a.Nationality.Name}");

            // So I have to know that I can't use some thing will return mulitple data for the same Actor, like for
            //   example I can't inclue the movies to get all the movies that the Actors make as the same actor may make
            //   more than one movie so I can't display his movies.
            // Also in the following example I just get the number of actors in each Nationality not the name of them, as if
            //   I want name of Actors then I have to repeat the name of nationality.
            var result23 = _context.Nationalities.Include(n => n.Actors).ToList();
            foreach (var a in result23)
                Console.WriteLine($"Nationality: \t {a.Name}\t  Actor: \t {a.Actors.Count()}");


            // I could inclued more than one table to get data from three or four or more tables.
            Console.WriteLine("-------------------------------------------");
            var result24 = _context.Movies
                .Include(m => m.Actors)
                .ThenInclude(a => a.Nationality)
                .ToList();

            foreach (var a in result24)
                Console.WriteLine($"Movie: \t {a.MovieTitle} \t Actor: \t {a.Actors.Count()}");


            /// Explicit Loading:
            // The differnce between Eager and Explicit loading is the Eager loading load data from all the inclueded
            //    tables at the same time even If you don't need it, On the other hand the Explicit loading load data
            //    form the main table then from the inclueded table if you need.
            var result25 = _context.Actors.SingleOrDefault(a => a.Id == 4);
            // until now we didn't inclued any other data from another table, and if I want to add data from another
            //   table which has a refernce as a navgation not as a list which mean the relation from the Actor to the
            //    other table is one from the Actor side like the relation between the Acotr and Nationality.
            Console.WriteLine("-------------------------------------------");
            _context.Entry(result25).Reference(a => a.Nationality).Load();
            Console.WriteLine(result25.Nationality.Name); // American

            // we said that we used the Reference as the relation is one from the Actors, but if the relation is many
            //    from the Actor then we have to use Collection.
            Console.WriteLine("-------------------------------------------");
            _context.Entry(result25).Collection(a => a.Movies).Load();
            foreach (var a in result25.Movies)
                Console.WriteLine(a.MovieTitle); // lion hart
                                                 // run away
                                                 // fast

            // As you can see here we could now solve the problem of getting multiple data from another table to single
            //    record in my main table, like if I want to get all the movies that a specific Actor Act on them.

            //Also I could add a quary after getting collection to get more specific data.
            Console.WriteLine("-------------------------------------------");
            var re = _context.Entry(result25)
                .Collection(a => a.Movies)
                .Query()
                .Where(a => a.MovieTitle.Length >= 6)
                .ToList();
            foreach (var a in re)
                Console.WriteLine(a.MovieTitle);// lion hart
                                                // run away



            /// Lazy Loading
            // The lazy loading is opisite to Egaer Loading, AS we said befor the Eager loading load all the data from 
            //    Included tables at the same time of accessing the Main table.
            // But Lazy loading doesn't load data until you access the Navigation prop.
            // To get more infomation about Lazy loading and see examples you could go to:
            // https://learn.microsoft.com/en-us/ef/core/querying/related-data/lazy





            // We said before when we use Eager loading it load all data from all the Included tables, But I could use 
            //    function called splitQuery() which used to apply Eager loading in two or more queries.
            /*
                
            In Entity Framework Core, the SplitQuery method is used in combination with eager loading to optimize 
                the performance of queries that involve multiple related entities.
            Eager loading is the process of loading related entities along with the main entity in a single query to
                minimize the number of database round-trips.

            The SplitQuery method is particularly useful when you are eager loading multiple related entities, 
               and each entity has a large number of rows. 
            Without using SplitQuery, EF Core would generate a single SQL query that joins all the tables, potentially 
                resulting in a large result set. In such cases, the data might not fit into memory efficiently, leading
                to performance issues and increased memory consumption.

                Here's a brief explanation of the benefits of using SplitQuery with eager loading:

                Reduced Memory Usage:

                When you have a large result set involving multiple related entities, using SplitQuery allows EF Core to
                    generate separate SQL queries for each entity.
                Each query retrieves a subset of the data, reducing the amount of data loaded into memory at once.
                This can be especially beneficial when dealing with large datasets, preventing memory-related performance issues.
                Improved Performance:

                By splitting the query into multiple SQL queries, the database engine can optimize the execution plan for
                     each individual query, potentially improving performance.
                The smaller result sets returned by each query can be processed more efficiently.
                Better Scalability:

                When working with large datasets, SplitQuery can enhance the scalability of your application by avoiding
                    the need to load and process all data at once.
                It can be beneficial for scenarios where you are dealing with large amounts of related data and need to 
                    optimize both memory usage and query performance.
             */
            Console.WriteLine("-------------------------------------------");
            result22 = _context.Actors.Include(a => a.Nationality).AsSplitQuery().ToList();
            foreach (var a in result22)
                Console.WriteLine($"Name: \t {a.Name}\t  Nationality: \t {a.Nationality.Name}");






            /// Join Using Query
            // We could make join using query statment which is better as it's less complex than extenstion method join()

            Console.WriteLine("-------------------------------------------");
            var result26 = from a in _context.Actors
                           join n in _context.Nationalities
                           on a.ActorNationalityId equals n.Id
                           select new
                           {
                               Name = a.Name,
                               Nationality = n.Name
                           }; 

             foreach (var a in result26)
                            Console.WriteLine($"Name: \t {a.Name}\t Nationality: \t{a.Nationality}");




            // Also we could make mulit join in the same query.

            Console.WriteLine("-------------------------------------------");
            
            var result27 = from a in _context.Actors
                           join n in _context.Nationalities
                           on a.ActorNationalityId equals n.Id
                           join m in _context.Movies
                           on a.Id equals m.Id
                           select new
                           {
                               a.Id,
                               Actor = a.Name,
                               n.Name,
                               m.MovieTitle
                           };
            foreach (var a in result19)
                            Console.WriteLine($"ActorId: \t {a.ActorId} \t Name: \t {a.ActorName} \t Nationality: \t {a.Nationality} \t Movie: \t {a.MovieName}");









            /// SQL Syntax
            // We could use SQl Syntax to select data from data base, but this way is not recomended.
            Console.WriteLine("-------------------------------------------");
            //var result28 = _context.Employees.FromSqlRaw("SELECT * FROM EMPLOYEES").ToList();
            //foreach (var e in result28)
            //    Console.WriteLine($"Name: \t {e.Name} \t Salary: \t {e.NetSalary}");






            /// Globle Filtering:
            // We Could make a globle filter to specific table using Fluent API
            // For example if we want to make A globle filter for table Employee to get data for Employees whoes salary 
            //    is bigger than 0, then I could write the following line of code inside the ApplicationDbContext.onModelCreating method:
            //modelBuilder.Entity<Employee>().HasQueryFilter(e => e.NetSalary > 0);

            // Now After appling this line of code we don't need to write where(e => e.NetSalary > 0) when we select data
            //   From employee table as it will be applied by default.








            /// Update data inside database
            // We could update data in specific row inside database using update method.
            //_context.Update(new Employee { Id = 8, Name = "Mohammed", TotalSalary = 4000});
            // We have to use _Context.SaveChanges() to save all this changes todatabase.

            // We could also use entry() method to updata row
            //var currenEmployee = _context.Employees.Find(8);
            //var newEmployee = new Employee { Id = 8, Name = "Essam", TotalSalary = 7000 };
            //_context.Entry(currenEmployee).CurrentValues.SetValues(newEmployee);


            // If I want to change a specific data inside a record like just changing the total salary for any employee
            //    and let his name and other prop without changes If I used update and update just TotalSalary column 
            //    the other columns for this record will be null, so to avoid this we using:
            //var em = new Employee { Id = 1, TotalSalary = 6200 };
            //_context.Update(em);
            //_context.Entry(em).Property(e => e.Name).IsModified = false;
            // when we use IsMdified = false we make changes disables to this column at this record.





            /// Remove()
            // Now if I want to remove a specific row from database we could use the next 
            // first we have to select the row that will be deleted.
            //var result29 = _context.Employees.Find(23);
            //_context.Employees.Remove(result29);

            // Also I could delete more than one row at the same time using removeRange() method.
            // but first we have to select the range that we want to delete
            //var rangeToBeDeleted = _context.Employees.Where(e => e.Id > 10);
            //_context.Employees.RemoveRange(rangeToBeDeleted);









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
            // To do so we have to go to ApplicationDbContext.OnModelCreating and Write the following line of code.

            /*
             * modelBuilder.Entity<Nationality>()
                .HasMany(n => n.Actors)
                .WithOne(a => a.Nationality)
                .OnDelete(DeleteBehavior.Restrict);
             */

            // We could handle it with other way by setting null to the related data without deleting it this could happen
            //   by the next line of code.
            /*
             * modelBuilder.Entity<Nationality>()
                .HasMany(n => n.Actors)
                .WithOne(a => a.Nationality)
                .OnDelete(DeleteBehavior.SetNull);
             */






            /// Transaction
            // In some situation we need to do some changes on database and we want all these changes to be applied to
            //  database at the same time which mean if one operation not applied then the other operations can't be applied
            //  and the programe will undo all the applied operations.
            // We could do this using Transaction.
            // code:
            using(var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    // We will put here all the operation that I want to make it happen at the same time.
                    // We have to put saveChanges after each operations.
                    _context.Employees.Add(new Employee {Name = "Mostafa", TotalSalary = 10300});
                    _context.SaveChanges();
                    var result = _context.Employees.Find(50);
                    _context.Remove(result);
                    _context.SaveChanges();

                    // After we end our operations then we have to write the next line of code to make it commit Transactoion
                    trans.Commit();

                }
                catch(System.Exception)
                {
                    // Inside the Catch block we will make the transaction rollback if any exception happen.
                    trans.Rollback();
                }
            }
            // This code will never happen as teh Find(50) will return return null so the Remove will never execute so this
            //   operation will make the Transaction stop the other operations.


            // I could Also add savePoint to back to this point if any error happen after this point.
            // For example If we have 4 operation and we make save point after the operation number 1, and this operation
            //   excute successful, but one of the other operations not excuted then our programe will commit all the
            //   operaions before the save point and not commit any operation after save point even if one of the oprations
            //   after save point excute successfully.
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    // We will put here all the operation that I want to make it happen at the same time.
                    // We have to put saveChanges after each operations.
                    _context.Employees.Add(new Employee { Name = "Mostafa", TotalSalary = 10300 });
                    _context.SaveChanges();
                    _context.Nationalities.Add(new Nationality { Name = "Plastinain"});
                    _context.SaveChanges();
                    // Here is a savepoint:
                    trans.CreateSavepoint("Save1");


                    var result = _context.Employees.Find(50);
                    _context.Remove(result);
                    _context.SaveChanges();

                    // After we end our operations then we have to write the next line of code to make it commit Transactoion
                    trans.Commit();

                }
                catch (System.Exception)
                {
                    // Inside the Catch block we will make the transaction rollback if any exception happen.
                    // Here we will back to the save point which mean i will undo all the operations after the savepoint
                    trans.RollbackToSavepoint("save1");
                    // then we will commit after the backing to savepoint to commit all the oprations before it to database.
                    trans.Commit();
                }
            }






            /// ExecuteDelete
            // Excute Delete method used to Delete data from data base with filtering or to delete all data in specific table.
            //_context.Employees.ExecuteDelete();
            // this line of code will delete all rows inside Employee table.

            // but the following code we used filtering with it to filter data.
            _context.Employees.Where(e => e.Id > 25).ExecuteDelete();


            ///ExecuteUpdate.
            // Execute Update used to Update all data inside table of specifc data using filtering.
            _context.Employees.Where(e => e.TotalSalary < 2000)
                .ExecuteUpdate(e => e.SetProperty(e => e.TotalSalary, e => e.TotalSalary + 1000));
            // When we use SetProperty method with EXecuteUpdateMethod we have to pot the prop that we want to update, then
            //   the new value.
            // The new value could be lamda expression.

            //_context.SaveChanges();
        }
        public static void seedingData()
        {
            // Using this funcion we could add data while database is creating.
            using(var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                var car = context.Cars.FirstOrDefault(b => b.Model == "BMW" && b.LicensePlate == "307");
                if (car == null)
                    context.Cars.Add(new Car { Model = "BMW", LicensePlate = "307" });
                context.SaveChanges();
            }
        }
    }
}