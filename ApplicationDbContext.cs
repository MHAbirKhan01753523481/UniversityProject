using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkAppp.Models;

namespace WorkAppp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<WorkAppp.Models.Category> Category { get; set; }
        public DbSet<WorkAppp.Models.SubCategory> SubCategory { get; set; }

        public DbSet<WorkAppp.Models.Review> Review { get; set; }

        public DbSet<WorkAppp.Models.OrderR> OrderR { get; set; }

        public DbSet<WorkAppp.Models.Employee> Employee { get; set; }

        public DbSet<WorkAppp.Models.Orderdetails> Orderdetails { get; set; }

        public DbSet<WorkAppp.Models.Metrial> Metrial { get; set; }

        public DbSet<WorkAppp.Models.Item> Item { get; set; }
    }
}
