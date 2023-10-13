using ElitaShop.Domain.Exceptions.Categories;
using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<bool> AddProductToCategoryAsync(long productId, long categoryId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);
            Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            if (product == null) throw new ProductNotFoundException();
            if (category == null) throw new CategoryNotFoundException();

            ProductCategory productCategory = new ProductCategory();
            productCategory.ProductId = productId;
            productCategory.CategoryId = categoryId;

            await _productCategoryRepository.AddAsync(productCategory);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> AddRangeProductsToCategoryAsync(List<long> productIds, long categoryId)
        {
            Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            if (category == null) throw new CategoryNotFoundException();

            List<ProductCategory> products = new List<ProductCategory>();


            foreach (long product in productIds)
            {
                Product? resultProduct = await _productRepository.GetAsync(prod => prod.Id == product);

                if (resultProduct != null)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.ProductId = resultProduct.Id;
                    productCategory.CategoryId = category.Id;
                    products.Add(productCategory);
                }
            }

            await _productCategoryRepository.AddRangeAsync(products);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long productId, long categoryId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);
            Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            if (product == null) throw new ProductNotFoundException();
            if (category == null) throw new CategoryNotFoundException();

            ProductCategory productCategory = new ProductCategory();
            productCategory.ProductId = productId;
            productCategory.CategoryId = categoryId;

            _productCategoryRepository.Remove(productCategory);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> DeleteRangeAsync(List<long> productIds, long categoryId)
        {
            Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            if (category == null) throw new CategoryNotFoundException();

            List<ProductCategory> products = new List<ProductCategory>();


            foreach (long product in productIds)
            {
                Product? resultProduct = await _productRepository.GetAsync(prod => prod.Id == product);

                if (resultProduct != null)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.ProductId = resultProduct.Id;
                    productCategory.CategoryId = category.Id;
                    products.Add(productCategory);
                }
            }

            _productCategoryRepository.RemoveRange(products);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<List<Product>> GetAllProductsInTheCategoryAsync(long categoryId)
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