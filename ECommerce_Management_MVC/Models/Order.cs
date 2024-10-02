using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Management_MVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("customer")]
        public string? Customer_Id { get; set; }
        public int amount { get; set; }
        public string Shipping_Address  { get; set; }
        public string Order_Address { get; set; }
        public string Order_Email { get; set; }
        public string Order_Date { get; set; }
        public string Order_Status { get; set; }

        public virtual Customer customer { set; get; }
        public virtual List<OrderDetail> orderDetails { get; set; }
    }
}
