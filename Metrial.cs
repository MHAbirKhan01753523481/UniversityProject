using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class Metrial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Store { get; set; }
        public double Supply { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int TotalQuantity { get; set; }
        public double AvailableQuantity { get; set; }
    }
}
