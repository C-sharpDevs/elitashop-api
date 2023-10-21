namespace ElitaShop.Services.Interfaces.Products
{
    public interface IProductReviewService
    {
        //Append
        Task<bool> CreateAsync(ProductReviewCreateDto productReviewCreateDto);

        //Update
        Task<bool> UpdateAsync(long productReviewId, ProductReviewUpdateDto productReviewUpdateDto);

        //Delete
        Task<bool> DeleteAsync(long productReviewId);

        //Get
        Task<IList<ProductReview>> GetAllAsync();

        //GetById
        Task<ProductReview> GetByIdAsync(long productReviewId);

        Task<List<ProductReview>> GetPageItmesAsync(PaginationParams @params);
    }
}
