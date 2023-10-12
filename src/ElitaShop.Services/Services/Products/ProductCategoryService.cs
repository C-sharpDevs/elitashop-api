using ElitaShop.Domain.Exceptions.Categories;
using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddProductToCategoryAsync(long productId, long categoryId)
        {
            //Product? product = await _productRepository.GetAsync(product => product.Id == productId);
            //Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            //if (product == null) throw new ProductNotFoundException();
            //if (category == null) throw new CategoryNotFoundException();

            //ProductCategory productCategory = new ProductCategory();
            //productCategory.ProductId = productId;
            //productCategory.CategoryId = categoryId;

            return true;
        }

        public Task<bool> AddRangeProductsToCategoryAsync(List<long> productIds, long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long productId, long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRangeAsync(List<long> productIds, long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsInTheCategoryAsync(long categoryId, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductCategoryAsync(long productId, long oldCategoryId, long newCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeProductsCategoryAsync(List<long> productIds, long oldCategoryId, long newCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
