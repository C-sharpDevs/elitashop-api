using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = unitOfWork.ProductRepository;
            _fileService = fileService;
        }
        public async Task<bool> CreateAsync(ProductCreateDto productCreateDto)
        {
            string imagepath = await _fileService.UploadImageAsync(productCreateDto.ProductImage);

            Product? product = _mapper.Map<Product>(productCreateDto);
            product.ProductImage = imagepath;
            product.PublishedAt = DateTime.UtcNow;
            product.StartAt = DateTime.UtcNow;
            await _productRepository.AddAsync(product);
            int result = await _unitOfWork.CommitAsync();

            if (result != 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(long productId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);


            if (product == null) throw new ProductNotFoundException();

            bool imageResult = await _fileService.DeleteImageAsync($"{product.ProductImage}");
            if (imageResult == false) throw new ImageNotFoundException();

            _productRepository.Remove(product);
            int result = await _unitOfWork.CommitAsync();


            if (result != 0)
                return true;
            return false;

        }
        public async Task<bool> UpdateAsync(long productId, ProductUpdateDto productUpdateDto)
        {
            Product? resultProduct = await _productRepository.GetAsync(product => product.Id == productId);

            if (resultProduct == null) throw new ProductNotFoundException();

            bool imageResult = await _fileService.DeleteImageAsync(resultProduct.ProductImage);
            if (imageResult == false) throw new ImageNotFoundException();

            string imagepath = await _fileService.UploadImageAsync(productUpdateDto.ProductImage);

            resultProduct = _mapper.Map<Product>(productUpdateDto);
            resultProduct.UpdatedAt = DateTime.UtcNow;
            resultProduct.ProductImage = imagepath;

            //resultProduct.Title = productUpdateDto.Title;
            //resultProduct.Description = productUpdateDto.Description;
            //resultProduct.MetaTitle = productUpdateDto.MetaTitle;
            //resultProduct.Price = productUpdateDto.Price;
            //resultProduct.Discount = productUpdateDto.Discount;
            //resultProduct.Quantity = productUpdateDto.Quantity;
            //resultProduct.ProductImage = imagepath;
            //resultProduct.UpdatedAt = DateTime.UtcNow;

            _productRepository.Update(resultProduct);
            int res = await _unitOfWork.CommitAsync();

            return res > 0;
        }

        public async Task<bool> UpdateImageAsync(long productId, IFormFile productImage)
        {
            Product? resultProduct = await _productRepository.GetAsync(product => product.Id == productId);

            if (resultProduct == null) throw new ProductNotFoundException();

            bool imageResult = await _fileService.DeleteImageAsync(resultProduct.ProductImage);

            if (imageResult == false) throw new ImageNotFoundException();

            resultProduct.ProductImage = await _fileService.UploadImageAsync(productImage);

            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            IEnumerable<Product>? products = await _productRepository.GetAllAsync();

            return products.ToList();
        }

        public async Task<Product> GetByIdAsync(long productId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);

            if (product == null) throw new ProductNotFoundException();

            return product;
        }

        public async Task<bool> DeleteRangeAsync(List<long> productIds)
        {
            foreach(long id in  productIds)
            {
                Product? product = await _productRepository.GetAsync(prod => prod.Id == id);

                _productRepository.Remove(product);
            }

            int result = await _unitOfWork.CommitAsync();
            return result > 0;
        }
    }
}