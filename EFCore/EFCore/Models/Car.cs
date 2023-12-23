using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Car
    {
        public int Id { get; set; }
        public string LicensePlate {  get; set; }
        public string Model { get; set; }
        public List<RecordOfSale> SaleHistory { get; set; }
    }
}
