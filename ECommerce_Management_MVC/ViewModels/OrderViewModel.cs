using ECommerce_Management_MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int amount { get; set; }
        public string Shipping_Address { get; set; }
        public string Order_Address { get; set; }
        [EmailAddress]
        public string Order_Email { get; set; }
        public DateTime Order_Date { get; set; }
        public string Order_Status { get; set; }

        public virtual Customer? customer { set; get; }
        public virtual List<OrderDetail>? orderDetails { get; set; }
    }
}
