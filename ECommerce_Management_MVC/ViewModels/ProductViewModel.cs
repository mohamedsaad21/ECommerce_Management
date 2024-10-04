using ECommerce_Management_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        [Required]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        [MaxLength(250), MinLength(5)]
        public string Descriptions { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Stock { get; set; }
        public virtual List<OrderDetail>? orderDetails { get; set; }
        public virtual List<product_category>? productCategories { get; set; }
		public List<Category>? categories { get; set; }
	}
}
