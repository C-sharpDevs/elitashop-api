using ElitaShop.DataAccess.Paginations;

public interface IProductCategoryRepository
{
    // Append
    Task<bool> AddProductToCategory(long productId,long categoryId);
    Task<bool> AddRangeProductsToCategory(List<long> productIds, long categoryId);
    
    // Delete
    Task<bool> Delete(long productId,long categoryId);
    Task<bool> DeleteRange(List<long> productIds, long categoryId);

    // Get
    Task<IList<Product>> GetAllProductsInTheCategory(long categoryId,PaginationParams @params);

    //Update
    Task<bool> UpdateProductCategory(long productId, long oldCategoryId, long newCategoryId);
    Task<bool> UpdateRangeProductsCategory(List<long> productIds, long oldCategoryId, long newCategoryId);
}