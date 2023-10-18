namespace ElitaShop.Services.Interfaces.CartItems
{
    public interface ICartItemService
    {
        Task<bool> CreateItemAsync(long cartId, CartItemCreateDto item);
        Task<bool> UpdateItemAsync(long cartItemId, CartItemUpdateDto item);
        Task<bool> DeleteItemAsync(long cartItemId);
        Task<CartItemGetDto> GetItemByIdAsync(long cartItemId);
        Task<List<CartItem>> GetAllItmesAsync(long cartId);
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}