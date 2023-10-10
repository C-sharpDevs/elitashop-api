namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ElitaShopDbContext dbContext) : base(dbContext) { }
    }
}
