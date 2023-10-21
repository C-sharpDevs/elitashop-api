namespace ElitaShop.Services.Interfaces.Products
{
    public interface IProductService
    {
        // Append
        Task<bool> CreateAsync(ProductCreateDto productCreateDto);

        // Update
        Task<bool> UpdateAsync(long productId, ProductUpdateDto productUpdateDto);
        Task<bool> UpdateImageAsync(long productId, IFormFile productImage);

        // Delete
        Task<bool> DeleteAsync(long productId);
        Task<bool> DeleteRangeAsync(List<long> productIds);

        // Get
        //Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long productId);
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}