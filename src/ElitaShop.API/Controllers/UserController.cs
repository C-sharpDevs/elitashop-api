using ElitaShop.DataAccess.Paginations;
using ElitaShop.Domain.Entities.Users;
using ElitaShop.Services.Dtos.User;

namespace ElitaShop.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly int maxPage = 25;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateAsync(userCreateDto);
            if (user)
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
        public async Task<IActionResult> GetPageItemsAsync([FromForm] int page = 1)
        {
            var users = await _userService.GetPageItmesAsync(new PaginationParams(page, maxPage));
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long userId)
        {
            User? user = await _userService.GetByIdAsync(userId);
            if (user != null)
                return Ok(user);
            return BadRequest("Not Found User");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] long userId, [FromForm] UserUpdateDto userUpdateDto)
        {
            bool update = await _userService.UpdateAsync(userId, userUpdateDto);
            if (update)
                return Ok("Updated");
            return BadRequest("Do not Updated");
        }

        [HttpGet]
        public async Task<IActionResult> GetImage(long userId)
        {
            var res = await _userService.GetImageAsync(userId);
            return Ok(res);
        }
    }
}
