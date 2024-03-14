using Food.API.DTO.Products;
using Food.API.Models.Products;
using Food.API.Repository;
using Food.API.Service.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = "allowedOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
        policy =>
        {
            policy.WithHeaders("Content-Type", "Authorization", "only-if-cached");
            policy.AllowAnyMethod();
            policy.WithOrigins("http://localhost:5173", "http://localhost:5174");
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(allowedOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();


static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IProductMapper, ProductMapper>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IProductRepository, ProductRepository>();
}