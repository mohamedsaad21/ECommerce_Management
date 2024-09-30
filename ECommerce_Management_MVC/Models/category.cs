namespace ECommerce_Management_MVC.Models
{
    public class category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string thumbnail { get; set; }
        public virtual List<product_category> product_Categories { get; set; } 
       // public virtual List<product_category> productCategories { get; set; }
    }
}
