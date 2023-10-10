using ElitaShop.Domain.Entities.Cards;

namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ElitaShopDbContext dbContext) : base(dbContext) { }
    }
}
