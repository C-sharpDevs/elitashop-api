using ElitaShop.Services.Interfaces.CartItems;
using ElitaShop.Domain.Exceptions.CartItems;
namespace ElitaShop.Services.Services.CartItems
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly long _cartId;

        public CartItemService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cartItemRepository = _unitOfWork.CartItemRepository;
            _httpContextAccessor = httpContextAccessor;
            var id = _httpContextAccessor.HttpContext.Request.Headers["cartId"].ToString();
            _cartId = long.Parse(id);
        }


        public async Task<bool> AddItemAsync(CartItemCreateDto item)
        {
            CartItem cartItem = _mapper.Map<CartItem>(item);
            cartItem.CartId = _cartId;

            _cartItemRepository.Add(cartItem);
            var result = await _unitOfWork.CommitAsync();

            return result > 0;
        }


        public async Task<bool> DeleteItemAsync(long cartItemId)
        {
            CartItem cartItem = await GetItemByIdAsync(cartItemId);
            _cartItemRepository.Remove(cartItem);

            var result = await _unitOfWork.CommitAsync();
            return result > 0;
        }

        public async Task<List<CartItem>> GetAllItmesAsync()
        {
            return (List<CartItem>)await _cartItemRepository.GetAllAsync(x => x.CartId == _cartId);
        }

        public async Task<CartItem> GetItemByIdAsync(long cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetAsync(x => x.CartId == cartItemId);
            if (cartItem == null)
            {
                throw new CartItemNotFound();
            }
            return cartItem;
        }

        public async Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params)
        {
            return (List<CartItem>)await _cartItemRepository.GetPageItemsAsync(@params);
        }

        public async Task<bool> UpdateItemAsync(long cartItemId, CartItemUpdateDto item)
        {
            CartItem cartItem = await GetItemByIdAsync(cartItemId);
            cartItem = _mapper.Map<CartItem>(item);
            cartItem.UpdatedAt = DateTime.UtcNow;
            _cartItemRepository.Update(cartItem);

            var result = await _unitOfWork.CommitAsync();
            return result > 0;
        }
    }
}
