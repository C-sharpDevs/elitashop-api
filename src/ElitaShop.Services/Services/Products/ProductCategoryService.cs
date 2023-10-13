using ElitaShop.Domain.Exceptions.Categories;

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

        public async Task<bool> UpdateProductCategoryAsync(long productId, long oldCategoryId, long newCategoryId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);
            if (product == null) throw new ProductNotFoundException();

            Category? category = await _categoryRepository.GetAsync(product => product.Id == newCategoryId);
            if (category == null) throw new CategoryNotFoundException();

            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(x => x.CategoryId == oldCategoryId && x.ProductId == productId);

            productCategory.CategoryId = newCategoryId;

            _productCategoryRepository.Update(productCategory);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> UpdateRangeProductsCategoryAsync(List<long> productIds, long oldCategoryId, long newCategoryId)
        {
            Category? category = await _categoryRepository.GetAsync(category => category.Id == oldCategoryId);

            if (category == null) throw new CategoryNotFoundException();

            List<ProductCategory> listProductCategory = new List<ProductCategory>();

            foreach (long i in productIds)
            {
                Product? product = await _productRepository.GetAsync(product => product.Id == i);

                ProductCategory productCategory = new ProductCategory();
                productCategory.ProductId = product.Id;
                productCategory.CategoryId = newCategoryId;
                listProductCategory.Add(productCategory);
            }

            _productCategoryRepository.AddRange(listProductCategory);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }
    }
}