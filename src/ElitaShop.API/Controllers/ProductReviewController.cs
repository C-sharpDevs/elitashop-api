using ElitaShop.DataAccess.Paginations;
using ElitaShop.Domain.Exceptions.Products;
using ElitaShop.Services.Dtos.Products;
using ElitaShop.Services.Interfaces.Product;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ElitaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductReviewController : Controller
    {
        private readonly IProductReviewService _productReviewService;
        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductReviewCreateDto productReviewCreateDto)
        {
            var result = await _productReviewService.CreateAsync(productReviewCreateDto);
            if (result)
                return Ok("Created");
            return BadRequest("Do not Created");
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long productReviewId)
        {
            var result = await _productReviewService.GetByIdAsync(productReviewId);
            if(result == null)
                throw new ProductReviewNotFoundException();
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var productReviews = await _productReviewService.GetAllAsync();
            return Ok(productReviews);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(long productReviewId)
        {
            var delete = await _productReviewService.DeleteAsync(productReviewId);
            if (delete == false)
                throw new ProductReviewNotFoundException();
            return Ok(delete);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(long productReviewId,ProductReviewUpdateDto productReviewUpdateDto)
        {
            var update = await _productReviewService.UpdateAsync(productReviewId, productReviewUpdateDto);
            if(update == false)
                throw new ProductReviewNotFoundException();
            return Ok(update);

        }


    }
}
