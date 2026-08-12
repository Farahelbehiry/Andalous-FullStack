using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private static readonly List<Products> _products = new();

        public IEnumerable<Products> GetAll()
        {
           return _products ;
        }
    }
}
