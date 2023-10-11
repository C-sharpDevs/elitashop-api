namespace ElitaShop.Services.Common.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            // Cart
            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>();

            // CartItem
            CreateMap<CartItemCreateDto, Cart>();
            CreateMap<CartItemUpdateDto, Cart>();

            // Category
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            // Order
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();

            // OrderItem
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItemUpdateDto, OrderItem>();

            // Product
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            // Product Review
            CreateMap<ProductReviewCreateDto, ProductReview>();
            CreateMap<ProductReviewUpdateDto, ProductReview>();

            // User
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
