using System.Linq.Expressions;

namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ElitaShopDbContext dbContext) : base(dbContext) { }

        
        public override Cart Get(Expression<Func<Cart, bool>> expression)
        {
            var cart = _entitySet.Include(x => x.CartItems).Where(expression).FirstOrDefault();
            return cart;
        }
    }
}
