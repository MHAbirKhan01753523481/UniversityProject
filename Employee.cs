using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [MinLength(5)]
        public string EmployeeName { get; set; }
        [Required]
        public string Present { get; set; }
       
    }
}
