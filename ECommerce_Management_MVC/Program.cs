using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce_Management_MVC.Models;
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


            app.Services.AddRole("Admin");
            app.Services.AddRole("User");
            app.Services.AddAdminRoles();
            app.Run();
        }
    }
    public static class RoleHelper
    {
        public static void AddRole(this IServiceProvider services, string v)
        {
            // ijnect explicitly RoleManager
            var RoleManger = services.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // create variable to take result of operation
            IdentityResult result;
            // check if role not exist
            if (!RoleManger.RoleExistsAsync(v).Result)
            {
                // create role using new IdentityRole
                result = RoleManger.CreateAsync(new IdentityRole(v)).Result;
            }
        }
        public static void AddAdminRoles(this IServiceProvider serviceProvider)
        {
            // inject explicitly UserManager and RoleManager
            var userManger = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<UserManager<Customer>>();
            var roleManger = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // inital result to recive result of operation
            IdentityResult result;
            // ensure from admin befor add role to him
            var user = userManger.FindByEmailAsync("Admin@gmail.com")?.Result;
            if (user == null)
            {
                user = new Customer() { FullName = "Admin", UserName = "Admin", Email = "Admin@gmail.com" };
                var resul = userManger.CreateAsync(user, "Ad@123").Result;
                if (!resul.Succeeded)
                {
                    throw new ArgumentException("admin not create d");
                }
            }

            // add every role to admin
            roleManger.Roles.ToList().ForEach(r =>
            {

                result = userManger.AddToRoleAsync(user, r.Name).Result;
            });
        }
    }
}
