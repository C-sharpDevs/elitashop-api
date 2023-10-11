namespace ElitaShop.Services.Dtos.Categories
{
    public class CategoryCreateDto
    {
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public IFormFile CategoryImage { get; set; } = default!;
    }
}
