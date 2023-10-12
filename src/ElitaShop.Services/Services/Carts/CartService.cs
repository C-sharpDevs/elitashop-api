using ElitaShop.Domain.Exceptions.Carts;
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

        public async Task<bool> CreateAsync(CartCreateDto cartCreateDto)
        {
            var cart = _mapper.Map<Cart>(cartCreateDto);
            
            await _cartRepository.AddAsync(cart);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long cartId)
        {
            var cart = _cartRepository.Get(x=> x.Id ==cartId);
            if(cart == null)
            {
                throw new CartNotFoundException();
            }
            _cartRepository.Remove(cart);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return (List<Cart>)await _cartRepository.GetAllAsync();
        }

        public async Task<Cart> GetCartByIdAsync(long cartId)
        {
            var cart = _cartRepository.Get(x => x.Id == cartId);
            if(cart == null)
            {
                throw new CartNotFoundException();
            }
            return cart;
        }

        public async Task<List<Cart>> GetPageItemsAsync(PaginationParams @params)
        {
            var result = await _cartRepository.GetPageItemsAsync(@params);
            return (List<Cart>)result;
        }

        public async Task<bool> UpdateAsync(long cartId, CartUpdateDto cartUpdateDto)
        {
            var cart = _cartRepository.Get(x=>x.Id == cartId);
            if(cart == null)
            {
                throw new CartNotFoundException();
            }
            var newCart = _mapper.Map<Cart>(cartUpdateDto);
            newCart.Id = cartId;
            _cartRepository.Update(newCart);
            await _unitOfWork.CommitAsync();
            return true;

        }
    }
}
