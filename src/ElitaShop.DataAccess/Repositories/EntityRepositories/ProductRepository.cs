namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
    }
}
