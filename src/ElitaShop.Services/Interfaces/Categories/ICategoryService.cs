using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.Services.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategoryCreateDto categoryCreateDto);
        
        Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto categoryUpdateDto);
        
        Task<bool> DeleteAsync(long categoryId);
        
        Task<Category> GetByIdAsync(long categoryId);
        
        Task<IList<Category>> GetAllAsync(PaginationParams @params);
    }
}
