using Microsoft.EntityFrameworkCore;

namespace ECommerce_Management_MVC.Models
{
    public class CommerceContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }

        public virtual DbSet<Orders> Order { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<product_category> Product_Categories { get; set; }

        public virtual DbSet<category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetailss { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ZIZOMACBOOKPRO\\SQL2022;Database=ECDB;Trusted_Connection=True;TrustServerCertificate=True");
            // base.OnConfiguring(optionsBuilder);
        }
    
    }
}
