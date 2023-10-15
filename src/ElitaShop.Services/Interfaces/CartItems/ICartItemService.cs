namespace ElitaShop.Services.Interfaces.CartItems
{
    public interface ICartItemService
    {
        Task<bool> CreateItemAsync(CartItemCreateDto item);
        Task<bool> UpdateItemAsync(long cartItemId, CartItemUpdateDto item);
        Task<bool> DeleteItemAsync(long cartItemId);
        Task<CartItem> GetItemByIdAsync(long cartItemId);
        Task<List<CartItem>> GetAllItmesAsync(long cartItemId);
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}