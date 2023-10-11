using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Services.Dtos.Carts;

namespace ElitaShop.Services.Interfaces.Carts
{
    public interface ICartService
    {
        Task<bool> CreateAsync(CartCreateDto cartCreateDto);
        Task<Cart> GetCartByIdAsync(long cartId);
        Task<bool> UpdateAsync(long cartId, CartUpdateDto cartUpdateDto);
        Task<bool> DeleteAsync(long cartId);
        Task<List<Cart>> GetAllAsync();
    }
}
