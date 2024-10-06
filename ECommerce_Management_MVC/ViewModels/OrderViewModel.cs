using ECommerce_Management_MVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; } 
        [Required]
        [Remote("CheckValidStock", "Order", AdditionalFields = "productId", ErrorMessage = "Stock is Invalid!!")]
        public int amount { get; set; }
        public string Shipping_Address { get; set; }
        public string Order_Address { get; set; }
        [EmailAddress]
        public string Order_Email { get; set; }
        public DateTime Order_Date { get; set; }
        public string Order_Status { get; set; }
        public string? CustomerId { get; set; }
        public virtual Customer? customer { set; get; }
        public virtual List<OrderDetail>? orderDetails { get; set; }
    }
}
