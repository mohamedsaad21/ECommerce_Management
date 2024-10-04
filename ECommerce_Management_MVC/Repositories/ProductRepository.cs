using ECommerce_Management_MVC.Models;
using SQLitePCL;

namespace ECommerce_Management_MVC.Repositories
{
    public class ProductRepository : IEntityRepository<Product>
    {
        private readonly CommerceContext _commerceContext;

        public ProductRepository(CommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _commerceContext.Products;
        }

        public Product GetById(int id)
        {
            return _commerceContext.Products.SingleOrDefault(p => p.Id == id);
        }
        public Product Add(Product entity)
        {
            _commerceContext.Products.Add(entity);
            _commerceContext.SaveChanges();
            return entity;
        }
        public void Update(Product entity)
        {
            _commerceContext.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _commerceContext.Products.Remove(entity);
        }

        public void Save()
        {
            _commerceContext.SaveChanges();
        }

    }
}
