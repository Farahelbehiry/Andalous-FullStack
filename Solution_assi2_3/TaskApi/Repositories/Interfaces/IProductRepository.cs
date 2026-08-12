using TaskApi.Models;


namespace TaskApi.Repositories.Interfaces
    
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAll();
        
    }
}
