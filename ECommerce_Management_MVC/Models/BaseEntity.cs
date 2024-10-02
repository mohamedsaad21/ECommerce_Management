using Microsoft.AspNetCore.Identity;

namespace ECommerce_Management_MVC.Models
{
    public class BaseEntity : IdentityUser
    {
        public string FullName { get; set; }
    }
}
