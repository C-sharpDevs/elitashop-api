namespace ElitaShop.DataAccess.Interfaces.BaseRepositories
{
    public interface IUnitOfWork
    {
        ICartRepository CartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductReviewRepository ProductReviewRepository { get; }
        IOrderRepository OrderRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
