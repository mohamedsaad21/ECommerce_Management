using ECommerce_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.Controllers
{
    public class ProductsController : Controller
    {
        CommerceContext context=new CommerceContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //ask model
            List<Product> products = context.Products.ToList();
            //send to view
            return View(products);
        }

        public IActionResult GetById(int id)
        {
            //ask model
            Product product = context.Products.SingleOrDefault(p => p.Id == id);
            //send to view
            return View(product);
        }

        public IActionResult GoToAddForm()
        {
            List<Product> products = context.Products.ToList();
            ViewBag.product = products;
            return View();
        }

        #region old add version
      

        #endregion

        public IActionResult SaveFormData( string Sku, string Name, decimal Price
            , float Weight, string Descriptions, string Thumbnail, string Image, string Category
            , DateTime CreateDate, int Stock)
        {
            Product pr = new Product()

            {

                
                Sku = Sku,
                Name = Name,
                Price = Price,
                Weight = Weight,
                Descriptions = Descriptions,
                Thumbnail = Thumbnail,
                Image = Image,
                Category = Category,
                Stock = Stock
            };
            
                context.Products.Add(pr);
                context.SaveChanges();
                return RedirectToAction("GetAll");
            
           
               
             
        }

        // begin of edit
        public IActionResult GoToEditForm(int id)
        {
            Product std = context.Products.SingleOrDefault(s => s.Id == id);
            return View(std);
        }

        public IActionResult SaveEditFormData(Product std)
        {
            context.Products.Update(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            Product std = context.Products.SingleOrDefault(s => s.Id == id);
            context.Products.Remove(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

    }
}
