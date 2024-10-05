using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Management_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEntityRepository<Product> _productsRepository;
        private readonly IEntityRepository<Category> _categorysRepository;
        private readonly IEntityRepository<product_category> _product_categoryRepository;


        public ProductController(IEntityRepository<Product> productsRepository, IEntityRepository<Category> categorysRepository, IEntityRepository<product_category> product_categoryRepository)
        {
            _productsRepository = productsRepository;
            _categorysRepository = categorysRepository;
            _product_categoryRepository = product_categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            List<Product> products = _productsRepository.GetAll().ToList();
            return View(products);
        }

        public IActionResult GetById(int id)
        {
            Product product = _productsRepository.GetById(id);

            if (product == null) 
                return NotFound();

            return View(product);
        }

        public IActionResult GetByCategoryId(int id)
        {
            var category = _categorysRepository.GetById(id);
            if(category == null)
                return NotFound();

            var products = _productsRepository.GetAll().Where(p => p.CategoryId == id).ToList();
            return View("GetAll", products);
        }
        public IActionResult GoToAddForm()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.categories = _categorysRepository.GetAll().ToList();
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveFormData(ProductViewModel ProductVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = ProductVM.Name,
                    Price = ProductVM.Price,
                    Weight = ProductVM.Weight,
                    Descriptions = ProductVM.Descriptions,
                    Stock = ProductVM.Stock,
                    CreateDate = ProductVM.CreateDate,
                    CategoryId = ProductVM.CategoryId,
                };
                if(ProductVM.Thumbnail != null)
                {
                    using var dataStream1 = new MemoryStream();
                    await ProductVM.Thumbnail.CopyToAsync(dataStream1);
                    product.Thumbnail = dataStream1.ToArray();
                }
                if(ProductVM.Image != null)
                {
                    using var dataStream2 = new MemoryStream();
                    await ProductVM.Image.CopyToAsync(dataStream2);
                    product.Image = dataStream2.ToArray();
                }
                product = _productsRepository.Add(product);
                _productsRepository.Save();

                //product_category Table
                var pc = new product_category
                {
                    category_id = product.CategoryId,
                    product_id = product.Id,
                };
                _product_categoryRepository.Add(pc);
                _product_categoryRepository.Save();
                return RedirectToAction("GetAll");
            }
            ProductVM.categories = _categorysRepository.GetAll().ToList();
            return View(nameof(GoToAddForm), ProductVM);
        }
        public IActionResult GoToEditForm(int id)
        {
            var product = _productsRepository.GetById(id);
            if (product == null)
                return NotFound();
            var ProductVM = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                Weight = product.Weight,
                Descriptions = product.Descriptions,
                Stock = product.Stock
            };
            ProductVM.categories = _categorysRepository.GetAll().ToList();
            return View(ProductVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEditFormData(ProductViewModel ProductVM)
        {
            if (ModelState.IsValid)
            {
                var product = _productsRepository.GetById(ProductVM.Id);
                if(product == null)
                    return NotFound();

                product.Name = ProductVM.Name;
                product.Price = ProductVM.Price;
                product.Weight = ProductVM.Weight;
                product.Descriptions = ProductVM.Descriptions;
                product.Stock = ProductVM.Stock;

                _productsRepository.Update(product);
                _productsRepository.Save();
                return RedirectToAction("GetAll");
            }
            ProductVM.categories = _categorysRepository.GetAll().ToList();
            return View(nameof(GoToEditForm), ProductVM);
        }
        public IActionResult Delete(int id)
        {
            var product = _productsRepository.GetById(id);
            if (product == null)
                return NotFound();
            _productsRepository.Delete(product);
            _productsRepository.Save();
            return RedirectToAction("GetAll");
        }
    }
}
