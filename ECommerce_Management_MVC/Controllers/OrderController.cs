using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.Repositories;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;

namespace ECommerce_Management_MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEntityRepository<Order> _orderRepository;
        private readonly IEntityRepository<Product> _productRepository;
        private readonly IEntityRepository<OrderDetail> _orderDetailRepository;
        private readonly UserManager<Customer> _userManager;

        public OrderController(IEntityRepository<Order> orderRepository, UserManager<Customer> userManager, IEntityRepository<Product> productRepository, IEntityRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
			var user = await _userManager.GetUserAsync(User);
			var userId = user?.Id; 
				var orders = _orderRepository.GetAll().Where(c => c.Customer_Id == userId).ToList();
            return View(orders);
        }
        public IActionResult GetById(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) 
                return NotFound();
            return View(order);
        }
        public IActionResult Add(int id)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.productId = id;
            return View(orderViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAdd(OrderViewModel OrderVM)
        {
            if (ModelState.IsValid)
            {
				var user = await _userManager.GetUserAsync(User);
				var userId = user?.Id;
				var order = new Order
                {
                    Customer_Id = userId,
                    amount = OrderVM.amount,
                    Order_Address = OrderVM.Order_Address,
                    Shipping_Address = OrderVM.Shipping_Address,
                    Order_Email = OrderVM.Order_Email,
                    Order_Status = OrderVM.Order_Status,
                };
                order.Order_Date = DateTime.Now;
                order = _orderRepository.Add(order);
                _orderRepository.Save();
                var product = _productRepository.GetById(OrderVM.productId);
                if (product == null)
                    return NotFound();
                var orderDetails = new OrderDetail
                {
                    ProductId = product.Id,
                    OrderId = order.Id,
                    Price = product.Price,
                    Sku = product.Sku,
                    Quantity = product.Stock
                };
                _orderDetailRepository.Add(orderDetails);
                _orderDetailRepository.Save();
				return RedirectToAction(nameof(GetAll));
            }
            return View(nameof(Add), OrderVM);
        }

        public IActionResult Edit(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return NotFound();
			OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.amount = order.amount;
            orderViewModel.Shipping_Address = order.Shipping_Address;
            orderViewModel.Order_Email = order.Order_Email;
            order.Order_Status = order.Order_Status;

			return View(orderViewModel);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(OrderViewModel OrderVM)
        {
            if (ModelState.IsValid)
            {
                var order = _orderRepository.GetById(OrderVM.Id);
				var user = await _userManager.GetUserAsync(User);
				var userId = user?.Id;

                order.Customer_Id = userId;
                order.amount = OrderVM.amount;
                order.Order_Address = OrderVM.Order_Address;
                order.Shipping_Address = OrderVM.Shipping_Address;
                order.Order_Email = OrderVM.Order_Email;
                order.Order_Status = OrderVM.Order_Status;
				
				_orderRepository.Update(order);
				_orderRepository.Save();
				return RedirectToAction(nameof(GetAll));
			}
            return View(nameof(Edit), OrderVM);
        }
        public IActionResult Delete(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
                return NotFound();
            _orderRepository.Delete(order);
            _orderRepository.Save();
            return RedirectToAction(nameof(GetAll));
        }
    }
}
