using ElitaShop.DataAccess.Paginations;

namespace ElitaShop.Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<bool> CreateAsync(UserCreateDto userCreateDto);
        
        Task<bool> UpdateAsync(long  userId, UserUpdateDto userUpdateDto);
        
        Task<bool> DeleteAsync(long userId);
        
        Task<User> GetByIdAsync(long userId);
        
        Task<IList<User>> GetAllAsync(PaginationParams @params);
    }
}
