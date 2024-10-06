using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IEntityRepository<Category> _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(IEntityRepository<Category> categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetAll(string searchString = "", int currentPage = 1, string term = "")
        {
            term = string.IsNullOrEmpty(term) ? "" : term.ToLower();
            var Categories = _categoryRepository.GetAll().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                Categories = Categories.Where(e => e.name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var CategoryData = new CategoryViewModel();
            var totalRecords = Categories.Count();
            int PageSize = 4;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            Categories = Categories.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
            CategoryData.CurrentPage = currentPage;
            CategoryData.TotalPages = totalPages;
            CategoryData.PageSize = PageSize;
            CategoryData.Term = term;
            CategoryData.Categories = Categories;
            return View(CategoryData);
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
        public async Task<IActionResult> SaveFormData(CategoryViewModel CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    name = CategoryVM.name,
                    description = CategoryVM.description,          
                };
                if (CategoryVM.Thumbnail != null)
                {
                    string folder = "img/categories/";
                    folder += Guid.NewGuid().ToString() + CategoryVM.Thumbnail.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await CategoryVM.Thumbnail.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    category.thumbnail = folder;
                }
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
        public async Task<IActionResult> SaveEditFormData(CategoryViewModel CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.GetById(CategoryVM.Id);

                if (category == null)
                    return NotFound();

                category.name = CategoryVM.name;
                category.description = CategoryVM.description;
                if (CategoryVM.Thumbnail != null)
                {
                    string folder = "img/categories/";
                    folder += Guid.NewGuid().ToString() + CategoryVM.Thumbnail.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await CategoryVM.Thumbnail.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    if (category.thumbnail != folder)
                        category.thumbnail = folder;
                }
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                return RedirectToAction("GetAll");
            }
            return View(nameof(GoToEditForm), CategoryVM);
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
            return RedirectToAction("GetAll");
        }
    }
}
