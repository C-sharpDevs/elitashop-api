using ElitaShop.Services.Dtos.Carts;
using ElitaShop.Services.Interfaces.Carts;
using Microsoft.AspNetCore.Mvc;

namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(long userId)
        {
            var result = await _cartService.GetAllAsync(userId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(long userId, CartCreateDto cartCreateDto)
        {
            var result = await _cartService.CreateAsync(userId, cartCreateDto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(long cartId, CartUpdateDto cartUpdateDto)
        {
            var result = await _cartService.UpdateAsync(cartId, cartUpdateDto);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long cartId)
        {
            var result = await _cartService.DeleteAsync(cartId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCartById(long cartId)
        {
            var result = await _cartService.GetCartByIdAsync(cartId);
            return Ok(result);
        }
    }
}