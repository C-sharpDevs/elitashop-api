using ElitaShop.Services.Dtos.Products;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto productCreateDto)
        {
            var result = await _productService.CreateAsync(productCreateDto);

            if (result)
                return Ok();
            return BadRequest();
        }

    }
}
