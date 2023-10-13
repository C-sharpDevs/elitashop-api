using ElitaShop.DataAccess.Interfaces.BaseRepositories;
using ElitaShop.DataAccess.Interfaces.EntityRepositories;
using ElitaShop.Domain.Exceptions.Products;
using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductReviewService(IProductReviewRepository productReviewRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _productReviewRepository = productReviewRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateAsync(ProductReviewCreateDto productReviewCreateDto)
        {
            ProductReview productReview = _mapper.Map<ProductReview>(productReviewCreateDto);
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
            await _unitOfWork.CommitAsync();

            return true;

        }

        public async Task<IList<ProductReview>> GetAllAsync(PaginationParams @params)
        {
            var productReviews = await _productReviewRepository.GetPageItemsAsync(@params);
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

            ProductReview productReview1 = _mapper.Map<ProductReview>(productReviewUpdateDto);
            _productReviewRepository.Update(productReview1);
            await _unitOfWork.CommitAsync();

            return true;



        }


    }
}
