using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Management_MVC.Models
{
    public class product_category
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("categories")]
        public int? category_id { get; set; }
        [ForeignKey("products")]
        public int? product_id { get; set; }
        public virtual category categories { get; set; }
        public virtual Product products { get; set; }

    }
}
