using ECommerce_Management_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Management_MVC.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        [Required, MaxLength(255), MinLength(20)]
        public string description { get; set; }
        public string? thumbnail { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public virtual List<product_category>? product_Categories { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
