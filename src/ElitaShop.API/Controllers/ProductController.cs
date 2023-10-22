using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly int maxPage = 25;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto productCreateDto)
        {
            bool result = await _productService.CreateAsync(productCreateDto);

            if (result)
                return Ok("Sucesfully Created");
            return BadRequest("Do Not Created");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<Product>? products = await _productService.GetAllAsync();

            if (products.Count() != 0)
                return Ok(products);
            return BadRequest("Products Not Found");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] long productId, [FromForm] ProductUpdateDto productUpdateDto)
        {
            bool result = await _productService.UpdateAsync(productId, productUpdateDto);

            if (result)
                return Ok("Sucesfully Updated");
            return BadRequest("Do Not Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            bool result = await _productService.DeleteAsync(productId);

            if (result)
                return Ok("Sucesfully Deleted");
            return BadRequest("Do Not Deleted");
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdProduct(long productId)
        {
            Product? product = await _productService.GetByIdAsync(productId);

            if (product != null)
                return Ok(product);
            return BadRequest("Product Not Found");
        }

        [HttpGet]
        public async Task<IActionResult> GetPageItemsAsync([FromQuery] int page = 1)
        {
            var products = await _productService.GetPageItmesAsync(new PaginationParams(page, maxPage));
            return Ok(products);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProductImage([FromForm] long productId, IFormFile productImage)
        {
            bool result = await _productService.UpdateImageAsync(productId,productImage);

            if (result)
                return Ok("Sucesfully Updated");
            return BadRequest("Do Not Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRangeAsync(List<long> productIds)
        {
            bool result = await _productService.DeleteRangeAsync(productIds);

            if (result)
                return Ok("Sucesfully deleted");
            return BadRequest("Do Not Deleted");
        }
    }
}
