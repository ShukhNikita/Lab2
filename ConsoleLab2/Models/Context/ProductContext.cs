using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab2.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<ActivityTypes> ActivityTypes { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<ProductionTypes> ProductionTypes { get; set; }
        public DbSet<MeasurementUnits> MeasurementUnits { get; set; }
        public DbSet<ProductReleasePlans> ProductReleasePlans { get; set; }
        public DbSet<OwnershipForms> OwnershipForms { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSalesPlans> ProductSalesPlans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.GetConnetion());
        }
    }
}
