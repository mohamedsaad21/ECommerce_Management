using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ECommerce_Management_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEntityRepository<Product> _productsRepository;
        private readonly IEntityRepository<Category> _categorysRepository;
        private readonly IEntityRepository<product_category> _product_categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(IEntityRepository<Product> productsRepository, IEntityRepository<Category> categorysRepository, IEntityRepository<product_category> product_categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productsRepository = productsRepository;
            _categorysRepository = categorysRepository;
            _product_categoryRepository = product_categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(string searchString = "", int currentPage = 1, string term = "")
        {
            term = string.IsNullOrEmpty(term) ? "" : term.ToLower();
            var Products = _productsRepository.GetAll().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                Products = Products.Where(e => e.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            var productData = new ProductViewModel();
            var totalRecords = Products.Count();
            int PageSize = 4;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            Products = Products.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
            productData.Products = Products;
            productData.CurrentPage = currentPage;
            productData.TotalPages = totalPages;
            productData.Term = term;
            productData.PageSize = PageSize;
            return View(productData);
        }

        public IActionResult GetById(int id)
        {
            Product product = _productsRepository.GetById(id);

            if (product == null) 
                return NotFound();

            return View(product);
        }

        public IActionResult GetByCategoryId(int id, int currentPage = 1, string term = "")
        {
            var category = _categorysRepository.GetById(id);
            if (category == null)
                return NotFound();
            term = string.IsNullOrEmpty(term) ? "" : term.ToLower();
            var Products = _productsRepository.GetAll().Where(p => p.CategoryId == id).ToList();
            var productData = new ProductViewModel();

            var totalRecords = Products.Count();
            int PageSize = 4;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
            Products = Products.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
            productData.CurrentPage = currentPage;
            productData.TotalPages = totalPages;
            productData.PageSize = PageSize;
            productData.Term = term;
            productData.Products = Products;
            return View("GetAll", productData);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GoToAddForm()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.categories = _categorysRepository.GetAll().ToList();
            return View(productViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
                    string folder = "img/products/";
                    folder += Guid.NewGuid().ToString() + ProductVM.Thumbnail.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await ProductVM.Thumbnail.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    product.Thumbnail = folder;
                }
                if (ProductVM.Image != null)
                {
                    string folder = "img/products/";
                    folder += Guid.NewGuid().ToString() + ProductVM.Image.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await ProductVM.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    product.Image = folder;
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
        [Authorize(Roles = "Admin")]
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
                Stock = product.Stock,   
                ThumbnailPath = product.Thumbnail,
                ImagePath = product.Image,
                CategoryId = product.CategoryId
            };
            ProductVM.categories = _categorysRepository.GetAll().ToList();
            return View(ProductVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveEditFormData(ProductViewModel ProductVM)
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
                product.CategoryId = ProductVM.CategoryId;
                if (ProductVM.Thumbnail != null)
                {
                    string folder = "img/products/";
                    folder += Guid.NewGuid().ToString() + ProductVM.Thumbnail.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await ProductVM.Thumbnail.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    if(product.Thumbnail != folder)
                        product.Thumbnail = folder;

                }
                if (ProductVM.Image != null)
                {
                    string folder = "img/products/";
                    folder += Guid.NewGuid().ToString() + ProductVM.Image.FileName;
                    var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await ProductVM.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    if (product.Image != folder)
                        product.Image = folder;
                }
                _productsRepository.Update(product);
                _productsRepository.Save();
                return RedirectToAction("GetAll");
            }
            ProductVM.categories = _categorysRepository.GetAll().ToList();
            return View(nameof(GoToEditForm), ProductVM);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productsRepository.GetById(id);
            if (product == null)
                return NotFound();
            if(product.Thumbnail != null && product.Image  != null)
            {
                try
                {
                    // Attempt to delete the Thumbnail
                    string thumbnailPath = Path.Combine(_webHostEnvironment.WebRootPath, product.Thumbnail);
                    if (System.IO.File.Exists(thumbnailPath))
                    {
                        System.IO.File.Delete(thumbnailPath);
                    }

                    // Attempt to delete the Image
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.Image);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                catch (IOException ex)
                {
                    // Log the exception if necessary
                    // Provide feedback or handle gracefully
                    Console.WriteLine("Error deleting file: " + ex.Message);
                    // Optionally return a message to the user or ignore this issue
                }
            }
            _productsRepository.Delete(product);
            _productsRepository.Save();
            return RedirectToAction("GetAll");
        }

        public IActionResult CheckPositive(int stock)
        {
            return stock >= 0? Json(true) : Json(false);
        }
    }
}
