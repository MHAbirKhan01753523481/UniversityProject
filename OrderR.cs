using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class OrderR
    {
        public int Id { get; set; }
        [Required]
        public string TableNo { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; }
        public double PaymentAmount { get; set; }
       
        public string PaymentType { get; set; }
        public string StatusType { get; set; }
        public int EmployeeId { get; set; }
        [Required]   
        public List<Orderdetails> OrderDeatils { get; set; }
    }
}
