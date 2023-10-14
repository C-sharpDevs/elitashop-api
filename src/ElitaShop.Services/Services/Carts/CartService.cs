using ElitaShop.Domain.Exceptions.Carts;
using ElitaShop.Services.Interfaces.Carts;

namespace ElitaShop.Services.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cartRepository = _unitOfWork.CartRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Cart>> GetAllAsync(long userId)
        {
            return (List<Cart>)await _cartRepository.GetAllAsync(x=>x.UserId == userId);
        }

        public async Task<Cart> GetCartByIdAsync(long cartId)
        {
            var cart = _cartRepository.Get(x => x.Id == cartId);
            if (cart == null)
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
        public async Task<bool> CreateAsync(long userId, CartCreateDto cartCreateDto)
        {
            var cart = _mapper.Map<Cart>(cartCreateDto);
            cart.UserId = userId;
            await _cartRepository.AddAsync(cart);
            var result = await _unitOfWork.CommitAsync();
           
            if(result>0)
            {
                _httpContextAccessor.HttpContext.Response.Headers.Add("cartId", cart.Id.ToString());
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(long cartId)
        {
            var cart = await GetCartByIdAsync(cartId);
            
            if (cart == null)
            {
                throw new CartNotFoundException();
            }
            
            _cartRepository.Remove(cart);
            var result = await _unitOfWork.CommitAsync();

            return result > 0;
        }


        public async Task<bool> UpdateAsync(long cartId, CartUpdateDto cartUpdateDto)
        {
            var cart = _cartRepository.Get(x => x.Id == cartId);
            if (cart == null)
            {
                throw new CartNotFoundException();
            }
            _mapper.Map(cartUpdateDto, cart);
            cart.UpdatedAt = DateTime.UtcNow;
            _cartRepository.Update(cart);
            var result = await _unitOfWork.CommitAsync();
            return result > 0;

        }
    }
}