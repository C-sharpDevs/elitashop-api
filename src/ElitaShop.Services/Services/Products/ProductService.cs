using ElitaShop.Services.Interfaces.Products;

namespace ElitaShop.Services.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        //private readonly IFileService _fileService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productRepository = unitOfWork.ProductRepository;
         //   _fileService = fileService;
        }
        public async Task<bool> CreateAsync(ProductCreateDto productCreateDto)
        {
            //string imagepath = await _fileService.UploadImageAsync(productCreateDto.ProductImage);

            Product? product = _mapper.Map<Product>(productCreateDto);
           // product.ProductImage = imagepath;
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

           // bool imageResult = await _fileService.DeleteImageAsync($"{product.ProductImage}");
            //if (imageResult == false) throw new ImageNotFoundException();

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

          //  bool imageResult = await _fileService.DeleteImageAsync($"{resultProduct.ProductImage}");
           // if (imageResult == false) throw new ImageNotFoundException();

            var product = _mapper.Map<Product>(productUpdateDto);
            _productRepository.Update(product);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params)
        {
            IEnumerable<Product>? products = await _productRepository.GetPageItemsAsync(@params);

            return products;
        }

        public async Task<Product> GetByIdAsync(long productId)
        {
            Product? product = await _productRepository.GetAsync(product => product.Id == productId);

            if (product == null) throw new ProductNotFoundException();

            return product;
        }

    }
}