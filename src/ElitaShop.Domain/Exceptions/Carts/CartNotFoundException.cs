namespace ElitaShop.Domain.Exceptions.Carts
{
    public class CartNotFoundException : NotFoundException
    {
        public CartNotFoundException() 
        {
            this.TitleMessage = "Cart not found !";
        }
    }
}
