using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetAll();
    }
}
