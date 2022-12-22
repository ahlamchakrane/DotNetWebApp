using System.Text.Json.Serialization;
using ProductsWebApplication.Helpers;
using ProductsWebApplication.Mappers;
using ProductsWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductServiceImpl>();
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();

builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<CategoriesMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();