using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Services.Dtos.Carts;

namespace ElitaShop.Services.Interfaces.Carts
{
    public interface ICartService
    {
        Task CreateAsync(CartCreateDto cartCreateDto);
        Task<Cart> GetCartByIdAsync(long id);
        Task UpdateAsync(CartUpdateDto cartUpdateDto);
        Task DeleteAsync();
        Task<List<Cart>> GetAllAsync();
    }
}
