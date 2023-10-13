using ElitaShop.Services.Interfaces.Product;

namespace ElitaShop.Services.Services.Products
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductReviewService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productReviewRepository = unitOfWork.ProductReviewRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(ProductReviewCreateDto productReviewCreateDto)
        {
            ProductReview productReview = _mapper.Map<ProductReview>(productReviewCreateDto);
            productReview.PublishedAt = DateTime.UtcNow;

            await _productReviewRepository.AddAsync(productReview);
            int result = await _unitOfWork.CommitAsync();
            return result != 0;
        }

        public async Task<bool> DeleteAsync(long productReviewId)
        {
            ProductReview productReview = await _productReviewRepository.GetAsync(productReview => productReview.ProductId == productReviewId);
            if (productReview == null)
                throw new ProductReviewNotFoundException();

            _productReviewRepository.Remove(productReview);
            int res = await _unitOfWork.CommitAsync();

            return res > 0;

        }

        public async Task<IList<ProductReview>> GetAllAsync()
        {
            var productReviews = await _productReviewRepository.GetAllAsync();
            return productReviews.ToList();
        }

        public async Task<ProductReview> GetByIdAsync(long productReviewId)
        {
            ProductReview productReview = await _productReviewRepository.GetAsync(productReview => productReview.ProductId == productReviewId);
            return productReview;

        }

        public async Task<bool> UpdateAsync(long productReviewId, ProductReviewUpdateDto productReviewUpdateDto)
        {
            ProductReview productReview = await _productReviewRepository.GetAsync(productReview => productReview.ProductId == productReviewId);
            if (productReview == null)
                throw new ProductReviewNotFoundException();

            productReview.ProductId = productReviewUpdateDto.ProductId;
            productReview.Title = productReviewUpdateDto.Title;
            productReview.Rating = productReviewUpdateDto.Rating;
            productReview.Published = productReviewUpdateDto.Published;
            productReview.Content = productReviewUpdateDto.Content;
            productReview.UpdatedAt = DateTime.UtcNow;

            _productReviewRepository.Update(productReview);
            int result = await _unitOfWork.CommitAsync();



            return result > 0;
        }


    }
}
