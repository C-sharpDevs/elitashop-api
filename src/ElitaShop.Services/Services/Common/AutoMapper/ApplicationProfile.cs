namespace ElitaShop.Services.Services.Common.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            #region Dto
            // Cart
            CreateMap<CartCreateDto, Cart>();
            CreateMap<CartUpdateDto, Cart>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // CartItem
            CreateMap<CartItemCreateDto, CartItem>();
            CreateMap<CartItemUpdateDto, CartItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                .ForMember(dest => dest.CartId, opt => opt.Ignore());
            CreateMap<CartItem, CartItemGetDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Disount, opt => opt.MapFrom(src => src.Product.Discount))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Title))
                .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Product.Description));

            // Category
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            // Product
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartAt, opt => opt.Ignore())
                .ForMember(dest => dest.EndAt, opt => opt.Ignore());

            // Product Review
            CreateMap<ProductReviewCreateDto, ProductReview>();
            CreateMap<ProductReviewUpdateDto, ProductReview>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore());

            // User
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Admin, opt => opt.Ignore())
                .ForMember(dest => dest.Vendor, opt => opt.Ignore());
            CreateMap<User, UserGetDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Intro, opt => opt.MapFrom(src => src.Intro))
                .ForMember(dest => dest.UserAvatar, opt => opt.Ignore());

            #endregion
            #region order
            // Order
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();

            // OrderItem
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItemUpdateDto, OrderItem>();
            #endregion

        }
    }
}
