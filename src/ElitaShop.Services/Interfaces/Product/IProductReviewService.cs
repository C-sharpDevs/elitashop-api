using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.Services.Interfaces.Product
{
    public interface IProductReviewService
    {
        //Append
        Task<bool> CreateAsync(ProductReviewCreateDto productReviewCreateDto);

        //Update
        Task<bool> UpdateAsync(long productReviewsId, ProductReviewUpdateDto productReviewUpdateDto);

        //Delete
        Task<bool> DeleteAsync(long productReviewsId);

        //Get
        Task<IList<ProductReview>> GetAllAsync(PaginationParams @params);

        //GetById
        Task<ProductReview> GetByIdAsync(long productReviewsId);





    }
}
