using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // Now what if I want to add new column that has data depend on another data in another two
        //   columns Which called computed columns.
        // For example if I want to add a TotalSalary and Taxes in Employees table and want to add new
        //   column called NetSalary which equal to the (TotalSalary - Taxes), We could do this
        //   operation using EFC.
        // We could do it using Fluent API not Data Annetaions.
        // To See this example back agin to ApplicationDbContext.OnModleCreating to see it.

        [Required, Column(TypeName = "Decimal(10, 2)")]
        public decimal TotalSalary {  get; set; }


        [Required, Column(TypeName = "Decimal(10, 2)")]
        public decimal Taxes {  get; set; }


        [Column(TypeName = "Decimal(10,2)")]
        public decimal NetSalary {  get; set; }
    }
}
