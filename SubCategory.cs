﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkAppp.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
