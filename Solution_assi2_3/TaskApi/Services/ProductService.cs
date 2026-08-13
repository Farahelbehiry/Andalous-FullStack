using TaskApi.Exceptions;
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
            bool nameExists = false;
            foreach (var p in _productRepository.GetAll())
            {
                if (p.Name == product.Name)
                {
                    nameExists = true;
                    break;
                }
            }

            if (nameExists)
                throw new ConflictException($"A product with the name '{product.Name}' already exists.");

            return _productRepository.Create(product);
        }

        public bool Delete(int id)
        {
            var deleted = _productRepository.Delete(id);
            if(!deleted)
            {
                throw new NotFoundException($"PRODUCT {id} not found");
            }
            return true;
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
