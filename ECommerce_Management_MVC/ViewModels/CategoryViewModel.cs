using ECommerce_Management_MVC.Models;

namespace ECommerce_Management_MVC.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
        public virtual List<product_category>? product_Categories { get; set; }
    }
}
