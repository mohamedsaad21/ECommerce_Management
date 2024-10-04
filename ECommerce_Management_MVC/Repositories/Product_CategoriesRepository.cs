using ECommerce_Management_MVC.Models;

namespace ECommerce_Management_MVC.Repositories
{
    public class Product_CategoriesRepository : IEntityRepository<product_category>
    {

        private readonly CommerceContext _commerceContext;

        public Product_CategoriesRepository(CommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public IEnumerable<product_category> GetAll()
        {
            return _commerceContext.Product_Categories;
        }

        public product_category GetById(int id)
        {
            return _commerceContext.Product_Categories.SingleOrDefault(p => p.id == id);
        }
        public product_category Add(product_category entity)
        {
            _commerceContext.Product_Categories.Add(entity);
            return entity;
        }
        public void Update(product_category entity)
        {
            _commerceContext.Product_Categories.Update(entity);
        }

        public void Delete(product_category entity)
        {
            _commerceContext.Product_Categories.Remove(entity);
        }

        public void Save()
        {
            _commerceContext.SaveChanges();
        }
    }
}
