using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services
{
    public class UserService:IuserRepo
    {
        private readonly IuserRepo _userRepo;
        public UserService(IuserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<User> CreateUser(User user)
        {
            return await _userRepo.CreateUser(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }
    }
}
