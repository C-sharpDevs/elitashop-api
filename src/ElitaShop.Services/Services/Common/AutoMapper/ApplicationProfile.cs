namespace ElitaShop.Services.Services.Common.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            #region Dto
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
            #endregion
            #region updates
            CreateMap<Cart, Cart>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<CartItem, CartItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId));
            CreateMap<User, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => src.Admin))
                .ForMember(dest => dest.Vendor, opt => opt.MapFrom(src => src.Vendor));
            CreateMap<Product, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PublishedAt, opt => opt.MapFrom(src => src.PublishedAt))
                .ForMember(dest => dest.StartAt, opt => opt.MapFrom(src => src.StartAt))
                .ForMember(dest => dest.EndAt, opt => opt.MapFrom(src => src.EndAt));
            CreateMap<Category, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));



            #endregion



        }
    }
}
