using ElitaShop.DataAccess.Interfaces.BaseRepositories;
using ElitaShop.DataAccess.Interfaces.EntityRepositories;
using ElitaShop.DataAccess.Paginations;
using ElitaShop.Services.Interfaces.Common;
using ElitaShop.Services.Interfaces.Users;

namespace ElitaShop.Services.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._fileService = fileService;
        }

        public Task<bool> CreateAsync(UserCreateDto userCreateDto)
        {
            
        }

        public Task<bool> DeleteAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long userId, UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
