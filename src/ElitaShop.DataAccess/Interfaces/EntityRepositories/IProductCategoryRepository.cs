namespace ElitaShop.DataAccess.Interfaces.EntityRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        public Task<List<Product>> GetAllProductsInTheCategoryAsync(long categoryId);
    }
}
