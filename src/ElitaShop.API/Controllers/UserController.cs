using ElitaShop.Domain.Entities.Users;
using ElitaShop.Services.Dtos.User;
using ElitaShop.Services.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElitaShop.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateAsync(userCreateDto);
            if(user)
                return Ok("Created");
            return BadRequest("Do not Created");
               
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<User> users = await _userService.GetAllAsync();
            if (User != null)
                return Ok(users);
            return BadRequest("Not Found User");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            var delete = await _userService.DeleteAsync(userId);
            if (delete)
                return Ok("Deleted");
            return BadRequest("Do not Deleted");


        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long userId)
        {
            User? user = await _userService.GetByIdAsync(userId);
            if (user != null)
                return Ok(user);
            return BadRequest("Not Found User");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromForm] long userId, UserUpdateDto userUpdateDto)
        {
            bool update = await _userService.UpdateAsync(userId, userUpdateDto);
            if (update)
                return Ok("Updated");
            return BadRequest("Do not Updated");

        }
    }
}
