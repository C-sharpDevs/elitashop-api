using ElitaShop.DataAccess.Interfaces.BaseRepositories;
using ElitaShop.DataAccess.Interfaces.EntityRepositories;
using ElitaShop.DataAccess.Repositories.BaseRepositories;
using ElitaShop.Domain.Entities.Carts;
using ElitaShop.Services.Dtos.Carts;
using ElitaShop.Services.Interfaces.Carts;

namespace ElitaShop.Services.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = _unitOfWork.CartRepository;
        }

        public Task CreateAsync(CartCreateDto cartCreateDto)
        {
            var cart =
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
