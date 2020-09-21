using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string ReviewStatus { get; set; }
        public int Rating { get; set; }
        public int ItemId { get; set; }
        public Item Items { get; set; }
    }
}
