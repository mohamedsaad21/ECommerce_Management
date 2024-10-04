using ECommerce_Management_MVC.Models;

namespace ECommerce_Management_MVC.Repositories
{
	public class Order_DetailsRepository : IEntityRepository<OrderDetail>
	{
		private readonly CommerceContext _commerceContext;

		public Order_DetailsRepository(CommerceContext commerceContext)
		{
			_commerceContext = commerceContext;
		}

		public OrderDetail Add(OrderDetail entity)
		{
			_commerceContext.OrderDetails.Add(entity);
			return entity;
		}

		public void Delete(OrderDetail entity)
		{
			_commerceContext.Remove(entity);
		}

		public IEnumerable<OrderDetail> GetAll()
		{
			return _commerceContext.OrderDetails;
		}

		public OrderDetail GetById(int id)
		{
			return _commerceContext.OrderDetails.SingleOrDefault(PD => PD.Id == id);
		}

		public void Save()
		{
			_commerceContext.SaveChanges();
		}

		public void Update(OrderDetail entity)
		{
			_commerceContext.OrderDetails.Update(entity);
		}
	}
}
