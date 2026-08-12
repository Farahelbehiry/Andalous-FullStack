using TaskApi.Models;


namespace TaskApi.Repositories.Interfaces
    
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAll();
        public Products GetById(int id);
        public Products Create(Products product);
        public Products Update(int id,Products updatedproduct);
        public bool Delete(int id);
        public Products UpdateNameField(int id, Products product);


    }
}
