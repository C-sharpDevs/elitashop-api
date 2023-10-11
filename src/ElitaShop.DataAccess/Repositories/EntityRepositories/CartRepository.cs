using Microsoft.EntityFrameworkCore;

namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ElitaShopDbContext dbContext) : base(dbContext) { }

        public async Task<Cart> GetCartWithItmesAsync(long id)
        {
            var cart = await _entitySet.Where(x=>x.Id == id).Include(y => y.CartItems).FirstOrDefaultAsync();
            return cart;
        }
        public async Task UpdateCartItem(CartItem cartItem)
        {

        }
    }
}
