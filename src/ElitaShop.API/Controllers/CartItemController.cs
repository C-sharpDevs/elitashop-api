using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly int maxPage = 25;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long cartItemId) 
        {
            var result = await _cartItemService.GetItemByIdAsync(cartItemId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPageItemsAsync([FromQuery] int page = 1)
        {
            var result = await _cartItemService.GetPageItmesAsync(new PaginationParams(page, maxPage));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(long cartId)
        {
            var result = await _cartItemService.GetAllItmesAsync(cartId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(long cartId, CartItemCreateDto cartItemCreateDto)
        {
            var result = await _cartItemService.CreateItemAsync(cartId, cartItemCreateDto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(long cartItemId, CartItemUpdateDto cartItemUpdateDto)
        {
            var result = await _cartItemService.UpdateItemAsync(cartItemId, cartItemUpdateDto);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long cartItemId)
        {
            var result = await _cartItemService.DeleteItemAsync(cartItemId);
            return Ok(result);
        }
        
    }
}
