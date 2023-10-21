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

        public async Task<bool> CreateAsync(long userId, CartCreateDto cartCreateDto)
        {
            var cart = _mapper.Map<Cart>(cartCreateDto);
            cart.UserId = userId;
            await _cartRepository.AddAsync(cart);
            var result = await _unitOfWork.CommitAsync();
           
            if(result>0)
            {
                //_httpContextAccessor.HttpContext.Response.Headers["cartId"] = cart.Id.ToString();
                return true;
            }
            return false;
        }

        public async Task<Cart> GetCartByIdAsync(long cartId)
        {
            var cart = await _cartRepository.GetAsync(x => x.Id == cartId);

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
            Cart? cart = await GetCartByIdAsync(cartId);

            if (cart is null) throw new CartNotFoundException();

            cart.FirstName = cartUpdateDto.FirstName;
            cart.LastName = cartUpdateDto.LastName;
            cart.MiddleName = cartUpdateDto.MiddleName;
            cart.PhoneNumber = cartUpdateDto.PhoneNumber;
            cart.Email = cartUpdateDto.Email;
            cart.SessionId = cartUpdateDto.SessionId;
            cart.Status = cartUpdateDto.Status;
            cart.Address1 = cartUpdateDto.Address1;
            cart.Address2 = cartUpdateDto.Address2;
            cart.City = cartUpdateDto.City;
            cart.Province = cartUpdateDto.Province;
            cart.Country = cartUpdateDto.Country;
            cart.Content = cartUpdateDto.Content;
            cart.UpdatedAt = DateTime.UtcNow;
            
            var result = await _unitOfWork.CommitAsync();
            return result > 0;

        }

        public async Task<List<Cart>> GetAllAsync(long userId)
        {
            return (List<Cart>)await _cartRepository.GetAllAsync(x => x.UserId == userId);
        }
    }
}