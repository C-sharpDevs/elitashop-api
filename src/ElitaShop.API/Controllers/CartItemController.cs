namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long itemId) 
        {
            var result = await _cartItemService.GetItemByIdAsync(itemId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(long cartId)
        {
            var result = await _cartItemService.GetAllItmesAsync(cartId);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CartItemCreateDto cartItemCreateDto)
        {
            var result = await _cartItemService.CreateItemAsync(cartItemCreateDto);
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
