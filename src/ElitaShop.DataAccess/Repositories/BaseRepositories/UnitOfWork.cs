using ElitaShop.DataAccess.Repositories.EntityRepositories;

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
        private IProductRepository _productRepository;
        private IProductReviewRepository _productReviewRepository;
        private IUserRepository _userRepository;

        public ICartRepository CartRepository 
        {
            get {
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

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
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
