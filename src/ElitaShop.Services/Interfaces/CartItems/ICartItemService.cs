namespace ElitaShop.Services.Interfaces.CartItems
{
    public interface ICartItemService
    {
        Task<bool> AddItemAsync(CartItemCreateDto item);
        Task<bool> UpdateItemAsync(long cartItemId, CartItemUpdateDto item);
        Task<bool> DeleteItemAsync(long cartItemId);
        Task<CartItem> GetItemByIdAsync(long cartItemId);
        Task<List<CartItem>> GetAllItmesAsync();
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}