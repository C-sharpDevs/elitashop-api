﻿namespace ElitaShop.Services.Interfaces.Products
{
    public interface IProductService
    {
        // Append
        Task<bool> CreateAsync(ProductCreateDto productCreateDto);

        // Update
        Task<bool> UpdateAsync(long productId, ProductUpdateDto productUpdateDto);

        // Delete
        Task<bool> DeleteAsync(long productId);

        // Get
        Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params);
        Task<Product> GetByIdAsync(long productId);
    }
}