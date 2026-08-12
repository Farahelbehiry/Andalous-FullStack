using TaskApi.Models;
namespace TaskApi.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Products> GetAll();
        public Products GetById(int id);
        public Products Create(Products product);
        public bool Update(int Id, Products Updatedproduct);
        public bool Delete(int Id);



    }
}
