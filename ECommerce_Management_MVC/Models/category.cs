using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
        public List<product_category> product_Categories { get; set; } 
    }
}
