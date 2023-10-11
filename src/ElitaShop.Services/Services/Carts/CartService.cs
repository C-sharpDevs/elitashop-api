using ElitaShop.DataAccess.Interfaces.BaseRepositories;
using ElitaShop.DataAccess.Interfaces.EntityRepositories;
using ElitaShop.Services.Interfaces.Carts;

namespace ElitaShop.Services.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cartRepository = _unitOfWork.CartRepository;
        }

        public async Task CreateAsync(CartCreateDto cartCreateDto)
        {
            var cart = _mapper.Map<Cart>(cartCreateDto);
            //cart.Id = Random.Shared.Next();
            await _cartRepository.AddAsync(cart);
            await _unitOfWork.CommitAsync();
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CartUpdateDto cartUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
