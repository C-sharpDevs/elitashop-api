namespace ElitaShop.DataAccess.Interfaces.EntityRepositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetCartWithItmesAsync(long id);
    }
}
