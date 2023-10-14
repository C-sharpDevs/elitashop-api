namespace ElitaShop.DataAccess.Repositories.BaseRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElitaShopDbContext _dbContext;

        public UnitOfWork(ElitaShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ICartRepository _cartRepository;
        private ICategoryRepository _categoryRepository;
        private IOrderRepository _orderRepository;
        public IProductRepository _productRepository;
        private IProductReviewRepository _productReviewRepository;
        private IUserRepository _userRepository;
        private IProductCategoryRepository _productCategoryRepository;

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                return _productCategoryRepository ??= new ProductCategoryRepository(_dbContext);
            }
        }

        public ICartRepository CartRepository
        {
            get
            {
                return _cartRepository ??= new CartRepository(_dbContext);
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_dbContext);
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_dbContext);
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_dbContext);
            }
        }
        public IProductReviewRepository ProductReviewRepository
        {
            get
            {
                return _productReviewRepository ??= new ProductReviewRepository(_dbContext);
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(_dbContext);
            }
        }

        public int Commit()
        {
            int result = _dbContext.SaveChanges();
            return result;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            int result = await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.DisposeAsync();
        }
    }
}
