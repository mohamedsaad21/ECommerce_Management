﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_Management_MVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public string Descriptions { get; set; }
        public string? Thumbnail { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public int Stock { get; set; }
        public virtual List<OrderDetail> orderDetails { get; set; }
        public virtual List<product_category> productCategories { get; set; }
       
        
    }
}
