using ElitaShop.Services.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace ElitaShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductCategoryController : Controller
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] long productId, long categoryId)
        {
            bool result = await _productCategoryService.AddProductToCategoryAsync(productId, categoryId);

            if (result)
                return Ok("Sucesfully Created");
            return BadRequest("Do Not Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromForm] long productId, long categoryId)
        {
            bool result = await _productCategoryService.DeleteAsync(productId, categoryId);

            if (result)
                return Ok("Sucesfully Created");
            return BadRequest("Do Not Deleted");
        }

        [HttpPost]
        public async Task<IActionResult> CreatedRangeAsync(List<long> prosuctIds, long categoryId)
        {
            bool result = await _productCategoryService.AddRangeProductsToCategoryAsync(prosuctIds, categoryId);

            if (result)
                return Ok("Sucesfully Created");
            return BadRequest("Do Not Created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRangeAsync(List<long> productIds, long categoryId)
        {
            bool result = await _productCategoryService.DeleteRangeAsync(productIds, categoryId);

            if (result)
                return Ok("Sucesfully Deleted");
            return BadRequest("Do Not Deleted");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(long productId, long oldCategoryId, long newCategoryId)
        {
            bool result = await _productCategoryService.UpdateProductCategoryAsync(productId, oldCategoryId, newCategoryId);

            if (result)
                return Ok("Sucesfully Updated");
            return BadRequest("Do Not Updated");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRangeAsync(List<long> productIds, long oldCategoryId, long newCategoryId)
        {
            bool result = await _productCategoryService.UpdateRangeProductsCategoryAsync(productIds, oldCategoryId, newCategoryId);

            if (result)
                return Ok("Sucesfully Updated");
            return BadRequest("Do Not Updated");
        }
    }
}
