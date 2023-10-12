namespace ElitaShop.Services.Interfaces.Carts
{
    public interface ICartService
    {
        Task<bool> CreateAsync(long userId, CartCreateDto cartCreateDto);
        Task<bool> UpdateAsync(long cartId, CartUpdateDto cartUpdateDto);
        Task<bool> DeleteAsync(long cartId);
        Task<Cart> GetCartByIdAsync(long cartId);
        Task<List<Cart>> GetAllAsync();
        Task<List<Cart>> GetPageItemsAsync(PaginationParams @params);
    }
}
