
namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    internal class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
        public override CartItem Get(Expression<Func<CartItem, bool>> expression)
        {
            return _entitySet.Where(expression).Include(p => p.Product).FirstOrDefault();
        }
        public override async Task<CartItem> GetAsync(Expression<Func<CartItem, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _entitySet.Where(expression).Include(p => p.Product).FirstOrDefaultAsync();
        }
    }
}
