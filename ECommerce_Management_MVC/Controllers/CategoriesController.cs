using ECommerce_Management_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        CommerceContext context = new CommerceContext();
        public IActionResult GetAll()
        {

            List<category> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult GetById(int id)
        {

            category sts = context.Categories.SingleOrDefault(s => s.id == id);

            return View(sts);
        }

        public IActionResult GoToAddForm()
        {
            List<category> category = context.Categories.ToList();
            ViewBag.categories = category;
            return View();
        }

        public IActionResult SaveFormData(string _name, string _description, string _thumbnail)
        {
            category ct = new category()
            {
                name = _name,
                description = _description,
                thumbnail = _thumbnail
            };

            context.Categories.Add(ct);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult GoToEditForm(int id)
        {
            category std = context.Categories.SingleOrDefault(s => s.id == id);
            return View(std);
        }

        public IActionResult SaveEditFormData(category std)
        {
            context.Categories.Update(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            category std = context.Categories.SingleOrDefault(s => s.id == id);
            context.Categories.Remove(std);
            context.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
