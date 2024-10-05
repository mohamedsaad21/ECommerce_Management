using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Products")]
        public int? ProductId { get; set; }
        public decimal Price { get; set; }
        public string? Sku { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }
        public virtual Order Order { get; set; }
        
    }
}
