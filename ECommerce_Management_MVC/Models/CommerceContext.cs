using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Management_MVC.Models
{
    public class CommerceContext : IdentityDbContext<BaseEntity>
    {
        public CommerceContext(DbContextOptions<CommerceContext> options):base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<product_category> Product_Categories { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
    }
}
