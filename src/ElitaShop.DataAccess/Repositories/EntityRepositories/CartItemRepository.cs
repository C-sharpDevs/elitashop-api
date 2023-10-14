namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    internal class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
    }
}
