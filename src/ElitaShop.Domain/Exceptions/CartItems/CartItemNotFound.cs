namespace ElitaShop.Domain.Exceptions.CartItems
{
    public class CartItemNotFound : NotFoundException
    {
        public CartItemNotFound()
        {
            this.TitleMessage = "Cart item not found !";
        }
    }
}
