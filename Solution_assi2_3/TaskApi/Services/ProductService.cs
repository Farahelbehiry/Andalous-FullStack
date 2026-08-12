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

        public Products Create(Products product)
        {
            return _productRepository.Create(product);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Products GetById(int id)
        {
           return _productRepository.GetById(id);
            
        }

        public Products Update(int id, Products Updatedproduct)
        {
            return (_productRepository.Update(id, Updatedproduct));
        }

        public Products UpdateNameField(int id, Products product)
        {
            return (_productRepository.UpdateNameField(id, product));
        }
    }
}
