using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IEntityRepository<Category> _categoryRepository;

        public CategoryController(IEntityRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetAll()
        {
            var categories = _categoryRepository.GetAll().ToList();
            return View(categories);
        }

        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return View(category);
        }

        public IActionResult GoToAddForm()
        {
            var category = new CategoryViewModel();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveFormData(CategoryViewModel CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    name = CategoryVM.name,
                    description = CategoryVM.description,
                    thumbnail = CategoryVM.thumbnail
                };

                _categoryRepository.Add(category);
                _categoryRepository.Save();
                return RedirectToAction("GetAll");
            }
            return View(nameof(GoToAddForm), CategoryVM);
        }

        public IActionResult GoToEditForm(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null)
                return NotFound();

            var categoryVM = new CategoryViewModel();
            categoryVM.name = category.name;
            categoryVM.description = category.description;
            categoryVM.thumbnail = category.thumbnail;
            return View(categoryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEditFormData(CategoryViewModel CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.GetById(CategoryVM.Id);

                if (category == null)
                    return NotFound();

                category.name = CategoryVM.name;
                category.description = CategoryVM.description;
                category.thumbnail = CategoryVM.thumbnail;

                _categoryRepository.Update(category);
                _categoryRepository.Save();
                return RedirectToAction("GetAll");
            }
            return View(nameof(GoToEditForm), CategoryVM);
        }
        public IActionResult Delete(int id)
        {
            Category std = _categoryRepository.GetById(id);
            _categoryRepository.Delete(std);
            _categoryRepository.Save();
            return RedirectToAction("GetAll");
        }
    }
}
