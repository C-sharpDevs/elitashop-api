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

        public Task<bool> CreateAsync(CartCreateDto cartCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
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

        public Task<bool> UpdateAsync(CartUpdateDto cartUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
