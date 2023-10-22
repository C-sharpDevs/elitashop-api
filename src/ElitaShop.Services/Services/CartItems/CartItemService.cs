using ElitaShop.Domain.Exceptions.CartItems;
using ElitaShop.Services.Interfaces.CartItems;

namespace ElitaShop.Services.Services.CartItems
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly long _cartId;

        public CartItemService(
            IMapper mapper, 
            IPaginator paginator,
            IUnitOfWork unitOfWork, 
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _paginator = paginator;
            _unitOfWork = unitOfWork;
            _cartItemRepository = _unitOfWork.CartItemRepository;
            _httpContextAccessor = httpContextAccessor;
            var id = _httpContextAccessor.HttpContext.Request.Headers["cartId"].ToString();
            //_cartId = long.Parse(id);
        }


        public async Task<bool> CreateItemAsync(long cartId, CartItemCreateDto item)
        {
            var items = (List<CartItem>)await _cartItemRepository.GetAllAsync(x => x.CartId == cartId);
            if (items.Any(x => x.ProductId == item.ProductId)) 
            {
                throw new Exception();
            }
            CartItem cartItem = _mapper.Map<CartItem>(item);
            cartItem.CartId = cartId;

            _cartItemRepository.Add(cartItem);
            var result = await _unitOfWork.CommitAsync();

            return result > 0;
        }


        public async Task<bool> DeleteItemAsync(long cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemId);
            _cartItemRepository.Remove(cartItem);

            var result = await _unitOfWork.CommitAsync();
            return result > 0;
        }

        public async Task<List<CartItem>> GetAllItmesAsync(long cartId)
        {
            return (List<CartItem>)await _cartItemRepository.GetAllAsync(x => x.CartId == cartId);
        }

        public async Task<CartItemGetDto> GetItemByIdAsync(long cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemId);
            if (cartItem == null)
            {
                throw new CartItemNotFound();
            }
            CartItemGetDto cartItemGetDto = _mapper.Map<CartItemGetDto>(cartItem);
            return cartItemGetDto;
        }

        public async Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params)
        {
            var cartItems = await _cartItemRepository.GetPageItemsAsync(@params);
            var count = await _cartItemRepository.CountAsync();
            _paginator.Paginate(count, @params);
            return (List<CartItem>)cartItems;
        }

        public async Task<bool> UpdateItemAsync(long cartItemId, CartItemUpdateDto item)
        {
            CartItem cartItem = await _cartItemRepository.GetAsync(x => x.Id == cartItemId) ?? throw new CartItemNotFound();

            cartItem.Quantity = item.Quantity;
            cartItem.Content = item.Content;
            cartItem.UpdatedAt = DateTime.UtcNow;

            _cartItemRepository.Update(cartItem);

            var result = await _unitOfWork.CommitAsync();
            return result > 0;
        }
    }
}
