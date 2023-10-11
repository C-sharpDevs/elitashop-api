using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.Services.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategoryCreateDto categoryCreateDto);
        
        Task<bool> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        
        Task<bool> DeleteAsync(long categoryId);
        
        Task<Category> GetByIdAsync(long categoryId);
        
        Task<Category> GetAllAsync(PaginationParams @params);
    }
}
