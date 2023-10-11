using ElitaShop.DataAccess.Paginations;

public interface IProductCategoryService
{
    // Append
    Task<bool> AddProductToCategoryAsync(long productId,long categoryId);
    Task<bool> AddRangeProductsToCategoryAsync(List<long> productIds, long categoryId);
    
    // Delete
    Task<bool> DeleteAsync(long productId,long categoryId);
    Task<bool> DeleteRangeAsync(List<long> productIds, long categoryId);

    // Get
    Task<IList<Product>> GetAllProductsInTheCategoryAsync(long categoryId,PaginationParams @params);

    //Update
    Task<bool> UpdateProductCategoryAsync(long productId, long oldCategoryId, long newCategoryId);
    Task<bool> UpdateRangeProductsCategoryAsync(List<long> productIds, long oldCategoryId, long newCategoryId);
}
