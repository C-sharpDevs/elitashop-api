using ElitaShop.DataAccess.Data;
using ElitaShop.DataAccess.Interfaces.BaseRepositories;
using ElitaShop.DataAccess.Repositories.BaseRepositories;
using ElitaShop.Services.Interfaces.CartItems;
using ElitaShop.Services.Interfaces.Carts;
using ElitaShop.Services.Interfaces.Common;
using ElitaShop.Services.Interfaces.Products;
using ElitaShop.Services.Services.CartItems;
using ElitaShop.Services.Services.Carts;
using ElitaShop.Services.Services.Common;
using ElitaShop.Services.Services.Common.AutoMapper;
using ElitaShop.Services.Services.Products;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApplicationProfile));
builder.Services.AddDbContext<ElitaShopDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();