using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Services.Interfaces.CartItems;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElitaShop.Services.Services.CartItems
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly long _cartId;

        public CartItemService(ICartRepository cartItemService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _cartRepository = cartItemService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            var id = _httpContextAccessor.HttpContext.Request.Headers["cartId"].ToString();
            _cartId = long.Parse(id);
            

        }
        

        public async Task AddItem(CartItemCreateDto item)
        {
            Cart cart = await _unitOfWork.CartRepository.GetCartWithItmesAsync(_cartId);

            var cartItem = _mapper.Map<CartItem>(item);
            cart.CartItems.Add(cartItem);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteItem(long cartItemId)
        {
            Cart cart = await _cartRepository.GetCartWithItmesAsync(cartItemId);
            CartItem item;
            try
            {
                item = cart.CartItems.First();
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            cart.CartItems.Remove(item);
            await _unitOfWork.CommitAsync();

        }

        public async Task<List<CartItem>> GetAllItmes()
        {
            var cart = await _cartRepository.GetCartWithItmesAsync(_cartId);
            var items = cart.CartItems.ToList();
            return items;
        }

        public async Task<CartItem> GetItem(long cartItemId)
        {
            var cart = await _cartRepository.GetCartWithItmesAsync(_cartId);
            CartItem item;
            try
            {
                item = cart.CartItems.First(x => x.Id == cartItemId);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return item;

        }

        public Task<List<CartItem>> GetPageItmesAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateItem(long cartItemId, CartItemUpdateDto updateItem)
        {
            Cart cart = await _cartRepository.GetCartWithItmesAsync(cartItemId);
            CartItem item;
            try
            {
                item = cart.CartItems.First(x=>x.Id==cartItemId);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            CartItem newItem = _mapper.Map<CartItem>(updateItem);
            cart.CartItems.Remove(item);
            newItem.Id = cartItemId;
            cart.CartItems.Add(newItem);
            await _unitOfWork.CommitAsync();
        }
    }
}
