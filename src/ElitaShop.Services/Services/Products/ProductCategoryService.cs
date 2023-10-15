using ElitaShop.Domain.Exceptions.Categories;
using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = unitOfWork.CategoryRepository;
            _productRepository = unitOfWork.ProductRepository;
            _productCategoryRepository = unitOfWork.ProductCategoryRepository;
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
            ProductCategory? product = await _productCategoryRepository.GetAsync(product => product.ProductId == productId && product.CategoryId == categoryId);

            _productCategoryRepository.Remove(product);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> DeleteRangeAsync(List<long> productIds, long categoryId)
        {
            Category? category = await _categoryRepository.GetAsync(category => category.Id == categoryId);

            if (category == null) throw new CategoryNotFoundException();


            foreach (long product in productIds)
            {
                ProductCategory? resultProduct = await _productCategoryRepository.GetAsync(prod => prod.ProductId == product && prod.CategoryId == category.Id);

                if (resultProduct != null)
                {
                    _productCategoryRepository.Remove(resultProduct);
                }
            }

            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<List<Product>> GetAllProductsInTheCategoryAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductCategoryAsync(long productId, long oldCategoryId, long newCategoryId)
        {

            Category? category = await _categoryRepository.GetAsync(product => product.Id == newCategoryId);
            if (category == null) throw new CategoryNotFoundException();

            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(x => x.CategoryId == oldCategoryId && x.ProductId == productId);

            if (productCategory != null)
            {
                productCategory.CategoryId = newCategoryId;
                productCategory.UpdatedAt = DateTime.UtcNow;

                _productCategoryRepository.Update(productCategory);
            }

            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> UpdateRangeProductsCategoryAsync(List<long> productIds, long oldCategoryId, long newCategoryId)
        {
            Category? category = await _categoryRepository.GetAsync(category => category.Id == oldCategoryId);

            if (category == null) throw new CategoryNotFoundException();

            foreach (long i in productIds)
            {
                ProductCategory? product = await _productCategoryRepository.GetAsync(prod => prod.ProductId == i && prod.CategoryId == category.Id);

                if (product != null)
                {
                    product.CategoryId = newCategoryId;
                    product.UpdatedAt = DateTime.UtcNow;
                    _productCategoryRepository.Update(product);
                }
            }

            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }
    }
}