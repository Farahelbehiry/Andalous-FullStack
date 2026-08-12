using TaskApi.Models;
using TaskApi.Repositories.Interfaces;
using TaskApi.Services.Interfaces;


namespace TaskApi.Sevices
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       

        public IEnumerable<Products> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
