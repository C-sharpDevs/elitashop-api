namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ElitaShopDbContext dbContext) : base(dbContext) { }
    }
}
