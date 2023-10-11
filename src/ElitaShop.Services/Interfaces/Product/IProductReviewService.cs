namespace ElitaShop.Services.Interfaces.Product
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
        Task<IList<ProductReview>> GetAllAsync(PaginationParams @params);

        //GetById
        Task<ProductReview> GetByIdAsync(long productReviewId);





    }
}
