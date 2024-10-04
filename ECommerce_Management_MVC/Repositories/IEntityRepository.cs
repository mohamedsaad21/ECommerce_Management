namespace ECommerce_Management_MVC.Repositories
{
    public interface IEntityRepository<T> 
    {
        IEnumerable<T> GetAll();    
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
