using ECommerce_Management_MVC.Models;
using SQLitePCL;

namespace ECommerce_Management_MVC.Repositories
{
    public class CategoryRepository : IEntityRepository<Category>
    {
        private readonly CommerceContext _commerceContext;

        public CategoryRepository(CommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _commerceContext.Categories;
        }

        public Category GetById(int id)
        {
            return _commerceContext.Categories.SingleOrDefault(p => p.id == id);
        }
        public Category Add(Category entity)
        {
            _commerceContext.Categories.Add(entity);
            return entity;
        }
        public void Update(Category entity)
        {
            _commerceContext.Categories.Update(entity);
        }

        public void Delete(Category entity)
        {
            _commerceContext.Categories.Remove(entity);
        }
        public void Save()
        {
            _commerceContext.SaveChanges();
        }


    }
}
