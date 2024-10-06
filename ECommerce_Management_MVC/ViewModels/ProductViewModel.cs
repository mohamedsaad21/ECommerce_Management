using ECommerce_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
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
        public string? ThumbnailPath { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        [Remote("CheckPositive", "Product", ErrorMessage = "Stock must be positive")]
        public int Stock { get; set; }
        public virtual List<OrderDetail>? orderDetails { get; set; }
        public virtual List<product_category>? productCategories { get; set; }
		public List<Category>? categories { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
