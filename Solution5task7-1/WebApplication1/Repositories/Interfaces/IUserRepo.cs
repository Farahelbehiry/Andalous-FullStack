using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IuserRepo
    {
        public Task<User>CreateUser(User user);

        public Task<List<User>>GetAll();

    }
}
