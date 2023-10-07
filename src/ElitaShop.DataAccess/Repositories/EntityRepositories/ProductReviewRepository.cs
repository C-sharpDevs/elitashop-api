namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class ProductReviewRepository : Repository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(ElitaShopDbContext elitaShopDbContext) : base(elitaShopDbContext) { }
    }
}
