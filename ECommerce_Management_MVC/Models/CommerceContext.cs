using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Management_MVC.Models
{
    public class CommerceContext : IdentityDbContext<BaseEntity>
    {
        public CommerceContext(DbContextOptions<CommerceContext> options):base(options)
        {
            
        }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<product_category> Product_Categories { get; set; }

        public virtual DbSet<category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
