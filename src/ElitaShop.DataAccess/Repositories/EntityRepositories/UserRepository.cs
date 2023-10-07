namespace ElitaShop.DataAccess.Repositories.EntityRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ElitaShopDbContext dbContext) : base(dbContext) { }
    }
}
