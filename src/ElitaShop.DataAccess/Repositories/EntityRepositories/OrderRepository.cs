namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
    }
}
