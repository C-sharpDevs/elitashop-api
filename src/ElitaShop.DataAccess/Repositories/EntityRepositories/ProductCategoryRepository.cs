namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
    }
}
