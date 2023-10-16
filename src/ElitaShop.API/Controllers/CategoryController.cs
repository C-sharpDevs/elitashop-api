namespace ElitaShop.API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto categoryCreateDto)
        {
            var category = await _categoryService.CreateAsync(categoryCreateDto);
            if (category)
                return Ok("Created");
            return BadRequest("Do not Created");

        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Category> category = await _categoryService.GetAllAsync();
            if (category != null)
                return Ok(category);
            return BadRequest("Not Found Category");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto categoryUpdateDto)
        {
            bool result = await _categoryService.UpdateAsync(categoryId, categoryUpdateDto);

            if (result)
                return Ok("Sucesfully Updated");
            return BadRequest("Do Not Updated");
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long categoryId)
        {
            Category? category = await _categoryService.GetByIdAsync(categoryId);
            if (category != null)
                return Ok(category);
            return BadRequest("Not found Category");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long categoryId)
        {
            var delete = await _categoryService.DeleteAsync(categoryId);
            if (delete)
                return Ok("Deleted");
            return BadRequest("Do not Deleted");
        }

    }
}
