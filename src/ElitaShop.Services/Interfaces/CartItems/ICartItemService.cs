namespace ElitaShop.Services.Interfaces.CartItems
{
    public interface ICartItemService
    {
        Task<bool> AddItem(CartItemCreateDto item);
        Task<bool> UpdateItem(long cartItemId, CartItemUpdateDto item);
        Task<bool> DeleteItem(long cartItemId);
        Task<CartItem> GetItemById(long cartItemId);
        Task<List<CartItem>> GetAllItmes();
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}