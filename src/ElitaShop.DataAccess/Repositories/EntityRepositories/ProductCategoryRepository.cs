namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }

        public async Task<List<Product>> GetAllProductsInTheCategoryAsync(long categoryId)
        {
            List<Product>? products = await _entitySet.Where(x => x.CategoryId == categoryId).Select(cp => cp.Product).ToListAsync();

            return products;
        }
    }
}
