using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ECommerce_Management_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'CommerceContextConnection' not found.");

            builder.Services.AddDbContext<CommerceContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<Customer, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<CommerceContext>().AddDefaultUI().AddDefaultTokenProviders();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IEntityRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IEntityRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IEntityRepository<Order>, OrderRepository>();
            builder.Services.AddScoped<IEntityRepository<product_category>, Product_CategoriesRepository>();
            builder.Services.AddScoped<IEntityRepository<OrderDetail>, Order_DetailsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.MapRazorPages();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.Run();
        }
    }
}
