using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class RecordOfSale
    {
        public int Id { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }

        // This is the forgine key from the Car model.
        // Go to ApplicationDbContext.OnModelCreating. to see how to handle this usig API
        public String CarLicensePlate { get; set; }
        public Car Car {  get; set; }
    }
}
