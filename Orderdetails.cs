using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class Orderdetails
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderRId { get; set; }
        public OrderR OrderR { get; set; }

    }
}
