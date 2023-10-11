namespace ElitaShop.Services.Interfaces.CartItems
{
    public interface ICartItemService
    {
        Task AddItem(CartItemCreateDto item);
        Task UpdateItem(long cartItemId, CartItemUpdateDto item);
        Task DeleteItem(long cartItemId);
        Task<CartItem> GetItem(long cartItemId);
        Task<List<CartItem>> GetAllItmes();
        Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params);
    }
}
