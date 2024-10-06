using ECommerce_Management_MVC.Models;
using ECommerce_Management_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerce_Management_MVC.Repositories
{
    public class OrderRepository : IEntityRepository<Order>
    {
        private readonly CommerceContext _commerceContext;
        private readonly UserManager<Customer> _userManager;

        public OrderRepository(CommerceContext commerceContext, UserManager<Customer> userManager)
        {
            _commerceContext = commerceContext;
            _userManager = userManager;
		}

        public IEnumerable<Order> GetAll()
        {
			return _commerceContext.Orders.Include(o => o.customer);
		}

        public Order GetById(int id)
        {
            return _commerceContext.Orders.SingleOrDefault(p => p.Id == id);
        }
        public Order Add(Order order)
        {
            _commerceContext.Orders.Add(order);
            return order;
        }
        public void Update(Order order)
        {
            _commerceContext.Orders.Update(order);
        }

        public void Delete(Order order)
        {
            _commerceContext.Orders.Remove(order);
        }

        public void Save()
        {
            _commerceContext.SaveChanges();
        }
    }
}
