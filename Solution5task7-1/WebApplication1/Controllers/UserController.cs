using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController:ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsers(User user)
        {
            return Created($"/api/user/{user.Id}", await _userService.CreateUser(user));
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
    }
}
