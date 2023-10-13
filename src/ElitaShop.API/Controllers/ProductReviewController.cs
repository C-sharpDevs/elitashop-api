using ElitaShop.DataAccess.Paginations;
using ElitaShop.Domain.Entities.Products;
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
            ProductReview? result = await _productReviewService.GetByIdAsync(productReviewId);
            if (result != null)
                return Ok(result);
            return BadRequest("Not found ProductReview");
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<ProductReview>? productReviews = await _productReviewService.GetAllAsync();
            if(productReviews != null )
                return Ok(productReviews);
            return BadRequest("Not Found ProductReview");
        }   
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(long productReviewId)
        {
            var delete = await _productReviewService.DeleteAsync(productReviewId);
            if(delete)
                return Ok("Deleted");
            return BadRequest("Do Not Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(long productReviewId,ProductReviewUpdateDto productReviewUpdateDto)
        {
            var update = await _productReviewService.UpdateAsync(productReviewId, productReviewUpdateDto);
            if (update)
                return Ok("Update ProductReview");
            return BadRequest("Do not Update");
        }


    }
}
