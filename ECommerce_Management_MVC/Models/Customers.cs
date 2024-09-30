using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Full_Name { get; set; }
        public string Biling_Address { get; set; }
        public string default_shipping_address{ get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public virtual List<Orders> Order { set; get; }
    }
}
