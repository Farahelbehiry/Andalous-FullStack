using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private static readonly List<Products> _products = new();

        public Products Create(Products product)
        {
            _products.Add(product);
            return product;
        }

        public bool Delete(int id)
        {
            var gonnadelete = GetById(id);
            if (gonnadelete == null)
                return false;
            _products.Remove(gonnadelete);
            return true;
        }

        public IEnumerable<Products> GetAll()
        {
           return _products ;
        }

        public Products GetById(int id)
        {
           
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Products Update(int id, Products updatedproduct)
        {
            var product = GetById(id);
            if(product == null)
                return null;
            
            product.Name = updatedproduct.Name;
            product.Price = updatedproduct.Price;

            return product;
        }

        public Products UpdateNameField(int id, Products product)
        {
            var gonnaupdate = GetById(id);
            if (gonnaupdate == null)
                return null;
            gonnaupdate.Name = product.Name;
            return gonnaupdate;

        }
    }
}
