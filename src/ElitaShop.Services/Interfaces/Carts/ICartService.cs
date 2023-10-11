using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Services.Dtos.Carts;

namespace ElitaShop.Services.Interfaces.Carts
{
    public interface ICartService
    {
        Task<bool> CreateAsync(CartCreateDto cartCreateDto);
        Task<Cart> GetCartByIdAsync(long id);
        Task<bool> UpdateAsync(CartUpdateDto cartUpdateDto);
        Task<bool> DeleteAsync();
        Task<List<Cart>> GetAllAsync();
    }
}
