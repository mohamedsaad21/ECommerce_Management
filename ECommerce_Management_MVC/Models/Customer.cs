using Microsoft.AspNetCore.Identity;

namespace ECommerce_Management_MVC.Models
{
    public class Customer : BaseEntity
    {
        public string? BillingAddress { get; set; }
        public string Default_Shipping_Address { get; set; }
        public string country { get; set; }
        public virtual List<Order>? Order { set; get; }
        public byte[]? ProfilePicture { get; set; }
    }
}
